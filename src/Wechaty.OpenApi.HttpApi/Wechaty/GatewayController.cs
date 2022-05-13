using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EventBus.Distributed;
using Wechaty.OpenApi.Handler;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/wechaty")]
    public class GatewayController : OpenApiController, IGatewayAppService
    {
        private readonly IGatewayAppService _gatewayAppService;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GatewayController(IGatewayAppService gatewayAppService,
            IDistributedEventBus distributedEventBus,
            IHttpContextAccessor httpContextAccessor)
        {
            _gatewayAppService = gatewayAppService;
            _distributedEventBus = distributedEventBus;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("start")]
        public Task StartAsync(WechatyOption wechatyOption, CancellationToken cancellationToken = default)
        {
            return _gatewayAppService.StartAsync(wechatyOption);
        }

        [HttpPost]
        [Route("stop")]
        public Task StopAsync()
        {
            return _gatewayAppService.StopAsync();
        }

        [HttpGet]
        [Route("event")]
        public async Task GetEvent(CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Response.ContentType = "text/event-stream; charset=utf-8";

            var data =
            $"id:{GuidGenerator.Create().ToString()}\n" +
            $"retry:1000\n" +
            $"event:message\n" +
            $"data:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n";

            var bytes = Encoding.UTF8.GetBytes(data);

            await httpContext.Response.Body.WriteAsync(bytes);
            await httpContext.Response.Body.FlushAsync();

            using (var consumer = new BlockingCollection<string>())
            {
                var eventGeneratorTask = EventGeneratorAsync(consumer, cancellationToken);
                foreach (var @event in consumer.GetConsumingEnumerable(cancellationToken))
                {
                    var payload =
                       $"id:{GuidGenerator.Create().ToString()}\n" +
                       $"retry:1000\n" +
                       $"event:message\n" +
                       $"data:{@event}\n\n";

                    bytes = Encoding.UTF8.GetBytes(payload);

                    await httpContext.Response.Body.WriteAsync(bytes);
                    await httpContext.Response.Body.FlushAsync(cancellationToken);
                }
                await eventGeneratorTask;
            }
        }

        private async Task EventGeneratorAsync(BlockingCollection<string> eventData, CancellationToken cacellationToken)
        {
            try
            {
                ConcurrentQueue<string> query = new ConcurrentQueue<string>();

                _distributedEventBus.Subscribe<EventStreamHandlerArgs>(data =>
                {
                    var str = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    //lock ((list as ICollection).SyncRoot)
                    //{
                    //    list.Add(str);
                    //}

                    query.Enqueue(str);
                    return Task.CompletedTask;
                });

                if (!cacellationToken.IsCancellationRequested)
                {
                    while (!eventData.IsCompleted)
                    {
                        //lock ((list as ICollection).SyncRoot)
                        //{
                        //    foreach (var item in list)
                        //    {
                        //        eventData.Add(item);
                        //    }
                        //    list.Clear();
                        //}

                        var item = string.Empty;
                        if (query.TryDequeue(out item))
                        {
                            eventData.Add(item);
                        }

                        await Task.Delay(1000, cacellationToken).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                eventData.CompleteAdding();
            }
        }


    }
}

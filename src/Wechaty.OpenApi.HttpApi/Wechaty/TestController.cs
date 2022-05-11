using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    public class TestController : OpenApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IDistributedEventBus _distributedEventBus;



        public TestController(IHttpContextAccessor httpContextAccessor, IDistributedEventBus distributedEventBus)
        {
            _httpContextAccessor = httpContextAccessor;
            _distributedEventBus = distributedEventBus;
        }


        [HttpGet]
        [Route("getEvent")]
        public async Task GetEvent(CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.ContentType != "text/event-stream; charset=utf-8")
            {
                httpContext.Response.ContentType = "text/event-stream; charset=utf-8";
            }

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
                var list = new List<string>();


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
                        //if (list.Count > 0)
                        //{
                        var result =
                         $"id:{GuidGenerator.Create().ToString()}\n" +
                         $"retry:1000\n" +
                         $"event:message\n" +
                         $"data:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n";

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

                        //}
                        await Task.Delay(1000, cacellationToken).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                eventData.CompleteAdding();
            }
        }


        [HttpGet]
        [Route("send")]
        public Task Send()
        {
            _distributedEventBus.PublishAsync<EventStreamHandlerArgs>(new EventStreamHandlerArgs()
            {
                BotName = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UserId = "userId",
                EventResponse = new EventResponse()
                {
                    EventType = EventType.RoomJoin,
                    Payload = "test"
                }
            });
            return Task.CompletedTask;
        }

      
        [HttpGet]
        public async Task aaa()
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


            byte[] ppp = null;

            _ = _distributedEventBus.Subscribe<EventStreamHandlerArgs>(data =>
              {

                  var str = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                  var bytes = Encoding.UTF8.GetBytes(str);
                  ppp = bytes;

                  //await HttpContext.Response.Body.WriteAsync(bytes);
                  //await HttpContext.Response.Body.FlushAsync();

                  Console.WriteLine($"订阅:{str}");

                  //sendEventStream(httpContext, data);


                  //var payload =
                  //  $"id:{GuidGenerator.Create().ToString()}\n" +
                  //  $"retry:1000\n" +
                  //  $"event:message\n" +
                  //  $"data:{Newtonsoft.Json.JsonConvert.SerializeObject(data)}\n\n";


                  //_= httpContext.Response.Body.WriteAsync(bytes);
                  //_= httpContext.Response.Body.FlushAsync();



                  return Task.CompletedTask.ContinueWith(async x =>
                    {
                        _ = httpContext.Response.Body.WriteAsync(bytes).ConfigureAwait(false);
                        _ = HttpContext.Response.Body.FlushAsync().ConfigureAwait(false);

                    });
              });
            Console.WriteLine("123");

            if (ppp?.Length > 0)
            {

            }







        }

    }
}

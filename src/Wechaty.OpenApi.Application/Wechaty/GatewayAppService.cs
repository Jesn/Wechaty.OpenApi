using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Users;
using Wechaty.Grpc.Client;
using Wechaty.GrpcClient.Factory;
using Wechaty.OpenApi.Handler;

namespace Wechaty.OpenApi.Wechaty
{
    /// <summary>
    /// Gateway
    /// </summary>
    public class GatewayAppService : OpenApiAppService, IGatewayAppService
    {

        private readonly IDistributedEventBus _localEventBus;

        public GatewayAppService(IGrpcClientFactory grpcClientFactory, ICurrentUser currentUser, IDistributedEventBus localEventBus)
            : base(grpcClientFactory, currentUser)
        {
            _localEventBus = localEventBus;
        }

        public async Task StartAsync(WechatyOption wechatyOption, CancellationToken cancellationToken = default)
        {
            var option = ObjectMapper.Map<WechatyOption, Grpc.Client.GrpcPuppetOption>(wechatyOption);

            // TODO 如果改成多实例，WechatyOption 里面的Name字段则要放开
            option.Name = WechatyPuppetConst.DefaultPuppetClientName;

            var _grpcClient = _grpcClientFactory.CreateClient(option);
            await _grpcClient.StartAsync();

            //_ = Task.Run(async () =>
            //  {
            //      var eventStream = await _grpcClient.EventStreamAsync();
            //      while (eventStream.ResponseStream.MoveNext(cancellationToken).Result)
            //      {
            //        //OnGrpcStreamEvent(eventStream.ResponseStream.Current);
            //        //eventStream.ResponseStream.Current;
            //        Console.WriteLine(eventStream.ResponseStream.Current.ToString());
            //      }
            //  });

            _ = EventStreamAsync(_grpcClient, wechatyOption);

        }


        private async Task StartGrpClient(GrpcPuppetOption option)
        {
            var _grpcClient = _grpcClientFactory.CreateClient(option);
            await _grpcClient.StartAsync();
        }

        private async Task EventStreamAsync(WechatyPuppetClient grpcClient, WechatyOption wechatyOption, CancellationToken cancellationToken = default)
        {
            var eventStream = grpcClient.EventStreamAsync();
            while (await eventStream.ResponseStream.MoveNext(default))
            {
                var currentEvent = eventStream.ResponseStream.Current;
                Console.WriteLine(currentEvent.ToString());

              
                EventStreamHandlerArgs args = new EventStreamHandlerArgs()
                {
                    //UserId = _currentUser.GetId(),
                    UserId = "userId",
                    BotName = wechatyOption.Name,
                    EventResponse = new EventResponse()
                    {
                        EventType = Enum.Parse<EventType>(currentEvent.Type.ToString()),
                        Payload = currentEvent.Payload,
                    }
                };

                await _localEventBus.PublishAsync(args);
            }
        }


        public async Task StopAsync()
        {
            var _grpcClient = _grpcClientFactory.GetClient(WechatyPuppetConst.DefaultPuppetClientName);
            await _grpcClient.StopAsync();
        }
    }
}

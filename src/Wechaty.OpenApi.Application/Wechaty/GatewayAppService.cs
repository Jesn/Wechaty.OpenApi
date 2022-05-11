using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
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

        private readonly IDistributedEventBus _eventBus;

        public GatewayAppService(IGrpcClientFactory grpcClientFactory, ICurrentUser currentUser, IDistributedEventBus eventBus)
            : base(grpcClientFactory, currentUser)
        {
            _eventBus = eventBus;
        }

        public async Task StartAsync(WechatyOption wechatyOption, CancellationToken cancellationToken = default)
        {
            try
            {
                var option = ObjectMapper.Map<WechatyOption, Grpc.Client.GrpcPuppetOption>(wechatyOption);

                // TODO 如果改成多实例，WechatyOption 里面的Name字段则要放开
                option.Name = WechatyPuppetConst.DefaultPuppetClientName;

                var _grpcClient = _grpcClientFactory.CreateClient(option);
                await _grpcClient.StartAsync();

                _ = EventStreamAsync(_grpcClient, wechatyOption);
            }
            catch (RpcException ex)
            {
                throw new UserFriendlyException(ex.Status.Detail,ex.Status.StatusCode.ToString());
            }
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

                await _eventBus.PublishAsync(args);
            }
        }


        public async Task StopAsync()
        {
            var _grpcClient = _grpcClientFactory.GetClient(WechatyPuppetConst.DefaultPuppetClientName);
            await _grpcClient.StopAsync();
        }
    }
}

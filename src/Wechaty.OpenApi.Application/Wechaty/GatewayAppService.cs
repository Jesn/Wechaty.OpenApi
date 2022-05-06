using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wechaty.GrpcClient.Factory;

namespace Wechaty.OpenApi.Wechaty
{
    public class GatewayAppService : OpenApiAppService, IGatewayAppService
    {
        public GatewayAppService(IGrpcClientFactory grpcClientFactory)
            : base(grpcClientFactory)
        {

        }

        public async Task StartAsync(WechatyOption wechatyOption)
        {
            var option = ObjectMapper.Map<WechatyOption, Grpc.Client.GrpcPuppetOption>(wechatyOption);

            // TODO 如果改成多实例，WechatyOption 里面的Name字段则要放开
            option.Name = WechatyPuppetConst.DefaultPuppetClientName;

            var _grpcClient = _grpcClientFactory.CreateClient(option);
            await _grpcClient.StartAsync();
        }

        public async Task StopAsync()
        {
            var _grpcClient = _grpcClientFactory.GetClient(WechatyPuppetConst.DefaultPuppetClientName);
            await _grpcClient.StopAsync();
        }
    }
}

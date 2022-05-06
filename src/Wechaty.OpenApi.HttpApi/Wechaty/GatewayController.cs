using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/wechaty")]
    public class GatewayController : OpenApiController, IGatewayAppService
    {
        private readonly IGatewayAppService _gatewayAppService;

        public GatewayController(IGatewayAppService gatewayAppService)
        {
            _gatewayAppService = gatewayAppService;
        }

        [HttpPost]
        [Route("start")]
        public Task StartAsync(WechatyOption wechatyOption)
        {
            return _gatewayAppService.StartAsync(wechatyOption);
        }

        [HttpPost]
        [Route("stop")]
        public Task StopAsync()
        {
            return _gatewayAppService.StopAsync();
        }
    }
}

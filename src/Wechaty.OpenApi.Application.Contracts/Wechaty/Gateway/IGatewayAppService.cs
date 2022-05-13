using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wechaty.OpenApi.Wechaty
{
    public interface IGatewayAppService : IApplicationService
    {
        Task StartAsync(WechatyOption wechatyOption, CancellationToken cancellationToken = default);
        Task StopAsync();

        
    }
}

using Volo.Abp.Application.Services;

namespace Wechaty.OpenApi;

public abstract class OpenApiAppService : ApplicationService
{
    protected OpenApiAppService()
    {
        ObjectMapperContext = typeof(OpenApiApplicationModule);
    }
}

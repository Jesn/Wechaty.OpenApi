using Wechaty.OpenApi.Localization;
using Volo.Abp.Application.Services;

namespace Wechaty.OpenApi;

public abstract class OpenApiAppService : ApplicationService
{
    protected OpenApiAppService()
    {
        LocalizationResource = typeof(OpenApiResource);
        ObjectMapperContext = typeof(OpenApiApplicationModule);
    }
}

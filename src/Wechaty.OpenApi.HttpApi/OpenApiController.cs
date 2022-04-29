using Wechaty.OpenApi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wechaty.OpenApi;

public abstract class OpenApiController : AbpControllerBase
{
    protected OpenApiController()
    {
        LocalizationResource = typeof(OpenApiResource);
    }
}

using Localization.Resources.AbpUi;
using Wechaty.OpenApi.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(OpenApiApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class OpenApiHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(OpenApiHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OpenApiResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}

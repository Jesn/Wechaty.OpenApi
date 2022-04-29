using Volo.Abp.Modularity;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(OpenApiApplicationModule),
    typeof(OpenApiDomainTestModule)
    )]
public class OpenApiApplicationTestModule : AbpModule
{

}

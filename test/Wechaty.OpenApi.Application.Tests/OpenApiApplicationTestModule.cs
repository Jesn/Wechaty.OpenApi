using Volo.Abp.Modularity;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(OpenApiApplicationModule)
    )]
public class OpenApiApplicationTestModule : AbpModule
{

}

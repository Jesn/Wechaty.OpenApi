using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(AbpDddApplicationContractsModule)
    )]
public class OpenApiApplicationContractsModule : AbpModule
{

}

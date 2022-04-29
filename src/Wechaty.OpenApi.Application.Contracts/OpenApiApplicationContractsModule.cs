using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(OpenApiDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class OpenApiApplicationContractsModule : AbpModule
{

}

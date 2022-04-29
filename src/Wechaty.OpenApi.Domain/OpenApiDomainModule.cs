using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OpenApiDomainSharedModule)
)]
public class OpenApiDomainModule : AbpModule
{

}

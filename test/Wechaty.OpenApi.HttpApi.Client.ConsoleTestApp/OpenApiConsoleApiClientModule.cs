using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OpenApiHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class OpenApiConsoleApiClientModule : AbpModule
{

}

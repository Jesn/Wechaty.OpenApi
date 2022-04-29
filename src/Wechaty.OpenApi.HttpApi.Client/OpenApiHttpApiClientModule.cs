using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Wechaty.OpenApi;

[DependsOn(
    typeof(OpenApiApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OpenApiHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OpenApiApplicationContractsModule).Assembly,
            OpenApiRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OpenApiHttpApiClientModule>();
        });

    }
}

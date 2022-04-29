using Wechaty.OpenApi.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wechaty.OpenApi;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(OpenApiEntityFrameworkCoreTestModule)
    )]
public class OpenApiDomainTestModule : AbpModule
{

}

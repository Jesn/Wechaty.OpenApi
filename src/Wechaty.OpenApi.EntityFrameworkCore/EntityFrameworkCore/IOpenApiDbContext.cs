using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Wechaty.OpenApi.EntityFrameworkCore;

[ConnectionStringName(OpenApiDbProperties.ConnectionStringName)]
public interface IOpenApiDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}

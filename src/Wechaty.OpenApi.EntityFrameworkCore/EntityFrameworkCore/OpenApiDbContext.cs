using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Wechaty.OpenApi.EntityFrameworkCore;

[ConnectionStringName(OpenApiDbProperties.ConnectionStringName)]
public class OpenApiDbContext : AbpDbContext<OpenApiDbContext>, IOpenApiDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public OpenApiDbContext(DbContextOptions<OpenApiDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureOpenApi();
    }
}

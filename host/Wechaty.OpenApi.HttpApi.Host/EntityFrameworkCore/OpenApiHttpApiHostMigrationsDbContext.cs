using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wechaty.OpenApi.EntityFrameworkCore;

public class OpenApiHttpApiHostMigrationsDbContext : AbpDbContext<OpenApiHttpApiHostMigrationsDbContext>
{
    public OpenApiHttpApiHostMigrationsDbContext(DbContextOptions<OpenApiHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOpenApi();
    }
}

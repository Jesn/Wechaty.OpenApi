using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wechaty.OpenApi.EntityFrameworkCore;

public class OpenApiHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<OpenApiHttpApiHostMigrationsDbContext>
{
    public OpenApiHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OpenApiHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("OpenApi"));

        return new OpenApiHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

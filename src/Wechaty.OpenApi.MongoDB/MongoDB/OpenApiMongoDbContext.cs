using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Wechaty.OpenApi.MongoDB;

[ConnectionStringName(OpenApiDbProperties.ConnectionStringName)]
public class OpenApiMongoDbContext : AbpMongoDbContext, IOpenApiMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureOpenApi();
    }
}

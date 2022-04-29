using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Wechaty.OpenApi.MongoDB;

[ConnectionStringName(OpenApiDbProperties.ConnectionStringName)]
public interface IOpenApiMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}

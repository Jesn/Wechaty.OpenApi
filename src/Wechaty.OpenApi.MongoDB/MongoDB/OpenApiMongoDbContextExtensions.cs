using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Wechaty.OpenApi.MongoDB;

public static class OpenApiMongoDbContextExtensions
{
    public static void ConfigureOpenApi(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}

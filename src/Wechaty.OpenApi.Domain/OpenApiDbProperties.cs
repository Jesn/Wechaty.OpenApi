namespace Wechaty.OpenApi;

public static class OpenApiDbProperties
{
    public static string DbTablePrefix { get; set; } = "OpenApi";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "OpenApi";
}

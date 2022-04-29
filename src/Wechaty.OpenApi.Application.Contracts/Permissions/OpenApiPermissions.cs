using Volo.Abp.Reflection;

namespace Wechaty.OpenApi.Permissions;

public class OpenApiPermissions
{
    public const string GroupName = "OpenApi";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(OpenApiPermissions));
    }
}

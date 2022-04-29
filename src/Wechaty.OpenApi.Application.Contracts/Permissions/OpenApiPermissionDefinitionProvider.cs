using Wechaty.OpenApi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wechaty.OpenApi.Permissions;

public class OpenApiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OpenApiPermissions.GroupName, L("Permission:OpenApi"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OpenApiResource>(name);
    }
}

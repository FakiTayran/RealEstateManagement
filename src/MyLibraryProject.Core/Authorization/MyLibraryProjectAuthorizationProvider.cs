using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyLibraryProject.Authorization
{
    public class MyLibraryProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customers"),multiTenancySides:MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Estates, L("Estates"),multiTenancySides:MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_EstatePictures, L("EstatePictures"),multiTenancySides:MultiTenancySides.Tenant);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyLibraryProjectConsts.LocalizationSourceName);
        }
    }
}

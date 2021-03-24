using Abp.Authorization;
using MyLibraryProject.Authorization.Roles;
using MyLibraryProject.Authorization.Users;

namespace MyLibraryProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

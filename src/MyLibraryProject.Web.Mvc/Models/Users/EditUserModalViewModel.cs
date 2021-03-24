using System.Collections.Generic;
using System.Linq;
using MyLibraryProject.Roles.Dto;
using MyLibraryProject.Users.Dto;

namespace MyLibraryProject.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}

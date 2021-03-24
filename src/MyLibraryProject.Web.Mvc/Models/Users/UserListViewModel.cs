using System.Collections.Generic;
using MyLibraryProject.Roles.Dto;

namespace MyLibraryProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

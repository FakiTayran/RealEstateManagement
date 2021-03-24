using System.Collections.Generic;
using MyLibraryProject.Roles.Dto;

namespace MyLibraryProject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

using System.Collections.Generic;
using MyLibraryProject.Roles.Dto;

namespace MyLibraryProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
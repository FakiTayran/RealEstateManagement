using Abp.AutoMapper;
using MyLibraryProject.Roles.Dto;
using MyLibraryProject.Web.Models.Common;

namespace MyLibraryProject.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}

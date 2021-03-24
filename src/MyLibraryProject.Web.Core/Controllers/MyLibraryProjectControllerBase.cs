using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyLibraryProject.Controllers
{
    public abstract class MyLibraryProjectControllerBase: AbpController
    {
        protected MyLibraryProjectControllerBase()
        {
            LocalizationSourceName = MyLibraryProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

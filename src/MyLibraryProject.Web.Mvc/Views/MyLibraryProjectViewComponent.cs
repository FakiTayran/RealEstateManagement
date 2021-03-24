using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyLibraryProject.Web.Views
{
    public abstract class MyLibraryProjectViewComponent : AbpViewComponent
    {
        protected MyLibraryProjectViewComponent()
        {
            LocalizationSourceName = MyLibraryProjectConsts.LocalizationSourceName;
        }
    }
}

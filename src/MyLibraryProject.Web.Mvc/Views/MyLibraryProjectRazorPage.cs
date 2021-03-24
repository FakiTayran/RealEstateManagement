using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MyLibraryProject.Web.Views
{
    public abstract class MyLibraryProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyLibraryProjectRazorPage()
        {
            LocalizationSourceName = MyLibraryProjectConsts.LocalizationSourceName;
        }
    }
}

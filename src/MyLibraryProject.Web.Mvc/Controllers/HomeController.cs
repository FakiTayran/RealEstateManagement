using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyLibraryProject.Controllers;

namespace MyLibraryProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyLibraryProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

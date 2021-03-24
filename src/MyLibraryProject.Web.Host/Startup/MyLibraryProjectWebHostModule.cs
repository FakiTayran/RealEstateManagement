using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLibraryProject.Configuration;

namespace MyLibraryProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MyLibraryProjectWebCoreModule))]
    public class MyLibraryProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyLibraryProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyLibraryProjectWebHostModule).GetAssembly());
        }
    }
}

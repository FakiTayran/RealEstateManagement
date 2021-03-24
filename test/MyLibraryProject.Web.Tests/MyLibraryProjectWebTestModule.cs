using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLibraryProject.EntityFrameworkCore;
using MyLibraryProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyLibraryProject.Web.Tests
{
    [DependsOn(
        typeof(MyLibraryProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyLibraryProjectWebTestModule : AbpModule
    {
        public MyLibraryProjectWebTestModule(MyLibraryProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyLibraryProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyLibraryProjectWebMvcModule).Assembly);
        }
    }
}
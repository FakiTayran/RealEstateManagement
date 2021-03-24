using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyLibraryProject.Authorization;

namespace MyLibraryProject
{
    [DependsOn(
        typeof(MyLibraryProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyLibraryProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyLibraryProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyLibraryProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

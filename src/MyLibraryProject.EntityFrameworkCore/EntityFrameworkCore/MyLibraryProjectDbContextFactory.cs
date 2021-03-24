using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyLibraryProject.Configuration;
using MyLibraryProject.Web;

namespace MyLibraryProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyLibraryProjectDbContextFactory : IDesignTimeDbContextFactory<MyLibraryProjectDbContext>
    {
        public MyLibraryProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyLibraryProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyLibraryProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyLibraryProjectConsts.ConnectionStringName));

            return new MyLibraryProjectDbContext(builder.Options);
        }
    }
}

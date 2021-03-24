using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyLibraryProject.EntityFrameworkCore
{
    public static class MyLibraryProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyLibraryProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyLibraryProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyLibraryProject.Authorization.Roles;
using MyLibraryProject.Authorization.Users;
using MyLibraryProject.MultiTenancy;
using MyLibraryProject.Models.Entities;

namespace MyLibraryProject.EntityFrameworkCore
{
    public class MyLibraryProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyLibraryProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyLibraryProjectDbContext(DbContextOptions<MyLibraryProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstatePicture> EstatePictures { get; set; }
    }
}

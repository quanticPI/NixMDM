using Microsoft.EntityFrameworkCore;
using NixMdm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NixMdm.Data
{
    public class MDMContext : DbContext
    {
        public MDMContext(DbContextOptions<MDMContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Device>().ToTable("Device");
            builder.Entity<DeviceUser>().ToTable("DeviceUsers");

        }

        public DbSet<Device> Device { get; set; }

        public DbSet<DeviceUser> DeviceUsers { get; set; }

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        public DbSet<Policy> Policy { get; set; }
    }
}
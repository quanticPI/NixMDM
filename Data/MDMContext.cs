using Microsoft.EntityFrameworkCore;
using NixMdm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NixMdm.Data
{
    public class MDMContext : IdentityDbContext
    {
        public MDMContext(DbContextOptions<MDMContext> options) :base(options)
        {
            
        }

        public DbSet<Device> Device { get; set; }

        public DbSet<User> DeviceUsers { get; set; }

        public DbSet<IdentityUser> IdentityUsers { get; set; }
    }
}
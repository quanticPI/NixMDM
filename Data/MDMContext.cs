using Microsoft.EntityFrameworkCore;
using NixMdm.Models;

namespace NixMdm.Data
{
    public class MDMContext : DbContext
    {
        public MDMContext(DbContextOptions<MDMContext> options) :base(options)
        {
            
        }

        public DbSet<Device> Device { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
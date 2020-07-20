using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using NixMdm.Data;

namespace NixMdm.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MDMContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MDMContext>>()))
            {
                // Look for any movies.
                if (context.Device.Any())
                {
                    return;   // DB has been seeded
                }

                context.Device.AddRange(
                    new Device
                    {
                        
                    },

                    new Device
                    {

                    },

                    new Device
                    {
                     
                    },

                    new Device
                    {

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
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

                context.Users.AddRange(
                    new User {ID = 1, Name = "Dan Don"}
                );
                context.SaveChanges();
                context.Device.AddRange(
                    new Device
                    {
                        
                        IMEI = "123456789",
                        Name = "Samsung",
                        UserID = 1,
                        PhoneNumber = "666837485",
                        OSVersion = "Android 10",
                        DateAdded = new DateTime(2020,2,12)
                    },

                    new Device
                    {
                        //Id = 2,
                        IMEI = "123456789",
                        Name = "HTC",
                        UserID = 1,
                        PhoneNumber = "666837485",
                        OSVersion = "Android 7",
                        DateAdded = new DateTime(2020,2,12)
                    },

                    new Device
                    {
                        //Id = 3,
                        IMEI = "123456789",
                        Name = "Xiaomi",
                        UserID = 1,
                        PhoneNumber = "666837485",
                        OSVersion = "Android 9",
                        DateAdded = new DateTime(2020,2,12)
                    },

                    new Device
                    {
                        //Id = 4,
                        IMEI = "123456789",
                        Name = "Samsung",
                        UserID = 1,
                        PhoneNumber = "666837485",
                        OSVersion = "Android 10",
                        DateAdded = new DateTime(2020,2,12)
                    }
                );

                 
                context.SaveChanges();
            }
        }
    }
}
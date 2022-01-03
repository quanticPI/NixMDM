using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using NixMdm.Models;

namespace NixMdm.Data
{
    public static class SeedData
    {
        public static void Initialize(MDMContext context)
        {
            var tempDeviceUser1 = new DeviceUser {Name = "Dan Don"};
            var tempDeviceUser2 = new DeviceUser {Name = "Kan Kon"};
            // Look for any movies.
            if (context.Device.Any())
            {
                return;   // DB has been seeded
            }

            context.DeviceUsers.AddRange(
                new DeviceUser[2] {tempDeviceUser1, tempDeviceUser2}
            );
            context.SaveChanges();
            context.Device.AddRange(
                new Device
                {
                    IMEI = "123456789",
                    Name = "Samsung",
                    User = tempDeviceUser1,
                    PhoneNumber = "666837485",
                    OSVersion = "Android 10",
                    DateAdded = new DateTime(2020,2,12)
                },

                new Device
                {
                    //Id = 2,
                    IMEI = "123456789",
                    Name = "HTC",
                    User = tempDeviceUser2,
                    PhoneNumber = "666837485",
                    OSVersion = "Android 7",
                    DateAdded = new DateTime(2020,2,12)
                },

                new Device
                {
                    //Id = 3,
                    IMEI = "123456789",
                    Name = "Xiaomi",
                    User = tempDeviceUser2,
                    PhoneNumber = "666837485",
                    OSVersion = "Android 9",
                    DateAdded = new DateTime(2020,2,12)
                },

                new Device
                {
                    //Id = 4,
                    IMEI = "123456789",
                    Name = "Samsung",
                    User = tempDeviceUser1,
                    PhoneNumber = "666837485",
                    OSVersion = "Android 10",
                    DateAdded = new DateTime(2020,2,12)
                }
            );
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NixMdm.Models;

namespace NixMdm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Device device1 = new Device
            {
                Id = 1,
                Name = "Samsung A50",
                IMEI = "EAORFIJHAUEOH",
                PhoneNumber = "666834485",
                OSVersion = "Android 9.0",
                UserID = 1
            };
            Device device2 = new Device
            {
                Id = 2,
                Name = "Samsung A80",
                IMEI = "EAORFIJHAUEOH",
                PhoneNumber = "666834485",
                OSVersion = "Android 9.1",
                UserID = 2
            };
            List<Device> listDevice = new List<Device>{device1, device2};
            return View(listDevice);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

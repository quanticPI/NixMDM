using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NixMdm.Models
{
    public class CreateDeviceViewModel
    {
        public string IMEI { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string OSVersion { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public List<SelectListItem> OSVersionList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "android", Text = "Android"},
            new SelectListItem { Value = "ios", Text = "iOS"}
        };
    }
}
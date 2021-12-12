using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NixMdm.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string IMEI { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        [Display (Name = "Operating System")]
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
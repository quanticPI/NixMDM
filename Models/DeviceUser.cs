using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NixMdm.Models
{
    public class DeviceUser
    {        
        [Key]
        public int Id {get; set; }
        public string Name { get;set; }
        public List<Device> Devices { get; set; }
    }
}
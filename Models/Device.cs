using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NixMdm.Models
{
    public class Device {
        
        [Key]
        public int Id { get; set; }
        public string IMEI{ get; set; }
        public string Name { get; set; }        
        public int UserID { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Operating System")]
        public string OSVersion { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded {get; set;}

        public void LockScreen() {
            throw new NotImplementedException();
        }
        
    }    
}
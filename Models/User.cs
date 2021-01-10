using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NixMdm.Models
{
    public class User
    {        
        [Key]
        public int Id {get; set; }
        public string Name {get;set;}        
    }
}
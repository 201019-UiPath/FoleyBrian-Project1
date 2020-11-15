using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerUI.Models
{
    public class Beer
    {
        public string ID { get;set; }
        [Required]
        public string Name {get; set;}
        [Required]
        public string Type {get; set;}
        [Required]
        public double ABV {get; set;}
        [Required]
        public short IBU {get; set;}
        [Required]
        public double Price {get; set;}
        public string BreweryID { get; set; }
        [Required]
        public int Keg { get; set; }
    }  
}
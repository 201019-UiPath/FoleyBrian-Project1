using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewCrewDB.Models
{
    public class Beer
    {
        [Key]
        public string ID { get;set; }
        public string Name {get; set;}
        public string Type {get; set;}
        public double ABV {get; set;}
        public short IBU {get; set;}
        public double Price {get; set;}  
    }  
}
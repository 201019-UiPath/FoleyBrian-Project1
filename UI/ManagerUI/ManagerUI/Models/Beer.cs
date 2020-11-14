using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerUI.Models
{
    public class Beer
    {
        public string ID { get;set; }
        public string Name {get; set;}
        public string Type {get; set;}
        public double ABV {get; set;}
        public short IBU {get; set;}
        public double Price {get; set;}
        public string BreweryID { get; set; }
        public int Keg { get; set; }
    }  
}
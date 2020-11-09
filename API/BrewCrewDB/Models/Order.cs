using System.Collections.Generic;
using System;

namespace BrewCrewDB.Models
{
    public class Order
    {
        public string ID {get; set;}
        public string UserID {get;set;}
        public User User {get;set;}
        public string BreweryID {get;set;}
        public Brewery Brewery {get;set;}
        public DateTime Date {get; set;}
        public short TableNumber {get;set;}
        public List<LineItem> LineItems {get; set;}
        public double TotalPrice {get;set;}
    }

    
}
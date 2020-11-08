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
        public string TableNumber {get;set;}
        public List<LineItem> LineItems {get; set;}
        public string TotalPrice {get;set;}
        //public string Quantity {get;set;}
        // public string CustomerID {get;set;}
        // public string BeerId {get;set;}
        // public string Date {get; set;}
        // public string TableNumber{get;set;}
        // public string BreweryId {get;set;}
        //  public string LineItemId {get;set;}

        // public void SetOrder(Dictionary<string,object> dictionary)
        // {   
        //     this.ID = Guid.NewGuid().ToString();
        //     this.CustomerID = (string)dictionary["customerId"];
        //     this.Date = DateTime.Now.ToString();
        //     this.TableNumber = (string)dictionary["tableNumber"];
        //     this.BreweryId = (string)dictionary["breweryId"];
        //     this.BeerId = (string)dictionary["beerId"];

        // }
    }

    
}
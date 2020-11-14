using System.Collections.Generic;

namespace ManagerUI.Models
{
    
    public class Brewery
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public short Zip {get;set;}
        public List<Beer> Beers {get;set;}
        public List<Order> Orders { get; set;}
        public List<BreweryManager> BreweryManagers { get; set; }
    }
}
using System.Collections.Generic;

namespace BrewCrewDB.Models
{
    
    public class Brewery
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public short Zip {get;set;}
        public List<BeerItem> BeerItems {get;set;}
    }
}
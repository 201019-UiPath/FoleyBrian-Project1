namespace BrewCrewDB.Models
{
    public class LineItem
    {
        public string ID {get;set;}
        public string OrderID {get;set;}
        public string BeerID {get;set;}
        public Beer Beer {get;set;}

        //what is the the structure of a database
        //schema
        //tables
        //indexes
        //triggers
    }
}
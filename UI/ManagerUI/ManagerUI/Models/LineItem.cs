using System.ComponentModel.DataAnnotations;

namespace ManagerUI.Models
{
    public class LineItem
    {
        public string ID {get;set;}
        public string OrderID {get;set;}
        public string BeerID {get;set;}
        public Beer Beer {get;set;}
    }
}
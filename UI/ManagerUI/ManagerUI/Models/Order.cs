using System.ComponentModel.DataAnnotations;

namespace ManagerUI.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string BreweryID { get; set; }
        public DateTime Date { get; set; }
        public short TableNumber { get; set; }
        public double TotalPrice { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
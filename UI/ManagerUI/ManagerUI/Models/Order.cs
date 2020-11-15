using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace ManagerUI.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string BreweryID { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Table Number")]
        public short TableNumber { get; set; }
        [DisplayName("Total")]
        public double TotalPrice { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
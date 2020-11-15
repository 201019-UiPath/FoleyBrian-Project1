using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerUI.Models
{
    public class User
    {
        public string ID {get; set;}
        public string FName {get; set;}
        public string LName {get; set;}
        [Required]
        [RegularExpression(@"[^\d!@#$%^&*()-_][\D\d]+@[\D]+.net?", ErrorMessage = "Not a valid Email address")]
        public string Email{get; set;}
        [Required]
        [DataType(DataType.Password, ErrorMessage ="Invalid Password")]
        public string Password{get; set;}
        public string Type{get;set;}
        public List<Order> Orders {get;set;}
    }
}
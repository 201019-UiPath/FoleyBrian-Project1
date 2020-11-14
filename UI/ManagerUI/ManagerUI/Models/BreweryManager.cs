using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManagerUI.Models
{
    public class BreweryManager
    {
        public string ID {get;set;}
        public string BreweryID {get;set;}
        public string UserID {get;set;}
        public User User {get;set;}
    }
}
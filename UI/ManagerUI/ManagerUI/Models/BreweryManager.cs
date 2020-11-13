
namespace BrewCrewDB.Models
{
    public class BreweryManager
    {
        public string ID {get;set;}
        public string BreweryID {get;set;}
        public string UserID {get;set;}
        public User User {get;set;}
    }
}
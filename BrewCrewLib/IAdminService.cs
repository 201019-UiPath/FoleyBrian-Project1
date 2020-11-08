using System;
using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public interface IAdminService
    {
        void AddBreweryManager(User manager, Brewery brewery);
        List<User> GetAllManagers();
        List<Brewery> GetAllBreweries();
        Brewery GetBrewerybyId(string breweryId);
        void DeleteBreweryById(string breweryId);
        void DeleteManagerById(string managerId);
    }
}

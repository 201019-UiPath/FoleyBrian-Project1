using System;
using System.Collections.Generic;
using BrewCrewDB.Models;

namespace BrewCrewLib
{
    public interface IManagerService
    {
        void AddBeer(Beer beer, string breweryId);
        List<Brewery> GetAllBreweries();
        List<Beer> GetAllBeersByBreweryId(string breweryId);
        void UpdateBeer(Beer beer);
        List<Order> GetOrderHistoryByBreweryId(string breweryId);
        Beer GetBeerById(string beerId);
        User GetCustomerById(string customerId);
        void AddManager(User manager, string breweryId);
        void DeleteManagerById(string managerId);
        void GetBreweryByManagerId(string managerId);

    }
}

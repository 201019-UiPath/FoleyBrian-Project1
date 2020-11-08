using System;
using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public interface ICustomerService
    {
        void AddCustomer(User customer);
        void PlaceOrder(Order order);
        User GetUserByEmail(string email);
        List<Brewery> GetAllBreweries();
        List<BeerItem> GetAllBeersByBreweryId(string breweryId);
        List<Order> GetAllOrdersByCustomerBreweryId(string customerId, string breweryId);
        Beer GetBeerById(string beerId);
        //void UpdateBeer(Beer beer);
        void DeleteCustomerById(string customerId);
    }
}

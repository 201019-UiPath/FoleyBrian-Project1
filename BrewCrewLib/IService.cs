using System;
using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public interface IService
    {
        void AddBeerItem(BeerItem entity);


        void DeleteBeerItem(BeerItem entity);


        BeerItem GetBeerItem(string id);


        IEnumerable<BeerItem> GetAllBeerItems();


        void UpdateBeerItem(BeerItem entity);


        void AddBeer(Beer entity);


        void DeleteBeer(Beer entity);


        Beer GetBeer(string id);


        IEnumerable<Beer> GetAllBeers();


        void UpdateBeer(Beer entity);


        void AddBrewery(Brewery entity);


        void DeleteBrewery(Brewery entity);


        Brewery GetBrewery(string id);


        IEnumerable<Brewery> GetAllBreweries();


        void UpdateBrewery(Brewery entity);


        void AddLineItem(LineItem entity);


        void DeleteLineItem(LineItem entity);


        LineItem GetLineItem(string id);


        IEnumerable<LineItem> GetAllLineItems();


        void UpdateLineItem(LineItem entity);


        void AddManagersJoint(ManagersJoint entity);


        void DeleteManagersJoint(ManagersJoint entity);


        ManagersJoint GetManagersJoint(string id);


        IEnumerable<ManagersJoint> GetAllManagersJoint();


        void UpdateManagersJoint(ManagersJoint entity);


        void AddOrder(Order entity);


        void DeleteOrder(Order entity);


        Order GetOrder(string id);


        IEnumerable<Order> GetAllOrders();


        void UpdateOrder(Order entity);


        void AddCustomer(User entity);


        void DeleteCustomer(User entity);


        User GetCustomer(string id);


        IEnumerable<User> GetAllCustomers();


        void UpdateCustomer(User entity);


        void AddManager(User entity);


        void DeleteManager(User entity);


        User GetManager(string id);


        IEnumerable<User> GetAllManagers();


        void UpdateManager(User entity);

    }
}

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


        List<BeerItem> GetAllBeerItems();


        void UpdateBeerItem(BeerItem entity);


        void AddBeer(Beer entity);


        void DeleteBeer(Beer entity);


        Beer GetBeer(string id);


        List<Beer> GetAllBeers();


        void UpdateBeer(Beer entity);


        void AddBrewery(Brewery entity);


        void DeleteBrewery(Brewery entity);


        Brewery GetBrewery(string id);


        List<Brewery> GetAllBreweries();


        void UpdateBrewery(Brewery entity);


        void AddLineItem(LineItem entity);


        void DeleteLineItem(LineItem entity);


        LineItem GetLineItem(string id);


        List<LineItem> GetAllLineItems();


        void UpdateLineItem(LineItem entity);


        void AddManagersJoint(ManagersJoint entity);


        void DeleteManagersJoint(ManagersJoint entity);


        ManagersJoint GetManagersJoint(string id);


        List<ManagersJoint> GetAllManagersJoint();


        void UpdateManagersJoint(ManagersJoint entity);


        void AddOrder(Order entity);


        void DeleteOrder(Order entity);


        Order GetOrder(string id);


        List<Order> GetAllOrders();


        void UpdateOrder(Order entity);


        void AddUser(User entity);


        void DeleteUser(User entity);


        User GetUser(string id);


        List<User> GetAllUsers();


        List<User> GetAllUsers(string identifier);


        void UpdateUser(User entity);

    }
}

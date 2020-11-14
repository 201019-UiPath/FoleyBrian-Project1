using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public interface IService<T>
    {
        void AddResource(T entity);
        void DeleteResource(string id);
        T GetResource(string id);
        List<T> GetAllResources();
        void UpdateResource(T entity);

        //Type Specific Calls
        User GetUserByEmail(string email);
        List<Beer> GetAllBeersByBreweryId(string id);
        List<User> GetAllUsersByType(string type);
        List<Order> GetAllOrdersByCustomerId(string id);
        List<Order> GetAllOrdersByBreweryId(string id);
    }
}

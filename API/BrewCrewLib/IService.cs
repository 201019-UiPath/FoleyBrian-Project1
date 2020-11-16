using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    /// <summary>
    /// Gets single resource by id
    /// </summary>
    public interface IService<T>
    {
        
        /// <summary>
        /// Adds Resource to the database
        /// </summary>
        /// <param name="entity">resource to add to the database</param>
        void AddResource(T entity);
        /// <summary>
        /// Deletes Resource from the database by id
        /// </summary>
        /// <param name="id">resource id</param>
        void DeleteResource(string id);
        /// <summary>
        /// Gets single resource by id
        /// </summary>
        /// <param name="id">id of resource</param>
        T GetResource(string id);
        /// <summary>
        /// Gets a list of all resources
        /// </summary>
        List<T> GetAllResources();
        /// <summary>
        /// Updates Resource in the database
        /// </summary>
        /// <param name="entity">resource to update</param>
        void UpdateResource(T entity);

        //Type Specific Calls
        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="email">user email string</param>
        User GetUserByEmail(string email);
        /// <summary>
        /// Gets all beers for a particular brewery using the brewery Id
        /// </summary>
        /// <param name="id">brewery id</param>
        List<Beer> GetAllBeersByBreweryId(string id);
        /// <summary>
        /// Gets users of a particular type (customer,manager) from the DB
        /// </summary>
        /// <param name="type">user type string</param>
        List<User> GetAllUsersByType(string type);
        /// <summary>
        /// Gets all orders for a particular customer using the custoer Id
        /// </summary>
        /// <param name="id">user id</param>
        List<Order> GetAllOrdersByCustomerId(string id);
        /// <summary>
        /// Gets all orders by brewery Id
        /// </summary>
        /// <param name="id">brewery id</param>
        List<Order> GetAllOrdersByBreweryId(string id);
    }
}

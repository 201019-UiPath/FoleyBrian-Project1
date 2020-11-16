using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    /// <summary>
    /// Repository handling all Database Operations
    /// </summary>
    public abstract class IDataRepo<TEntity>
    {
        public BrewCrewContext context;

        public IDataRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a list of all resources
        /// </summary>
        public abstract Task<List<TEntity>> GetAll();
        /// <summary>
        /// Gets single resource by id
        /// </summary>
        /// <param name="id">id of resource</param>
        public abstract Task<TEntity> GetById(string id);
        /// <summary>
        /// Adds Resource to the database
        /// </summary>
        /// <param name="entity">resource to add to the database</param>
        public abstract void Add(TEntity entity);
        /// <summary>
        /// Updates Resource in the database
        /// </summary>
        /// <param name="entity">resource to update</param>
        public abstract void Update(TEntity entity);
        /// <summary>
        /// Deletes Resource from the database by id
        /// </summary>
        /// <param name="id">resource id</param>
        public abstract void Delete(string id);

        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="email">user email string</param>
        public Task<User> GetUserByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).Include("Orders").FirstAsync();
        }

        /// <summary>
        /// Gets users of a particular type (customer,manager) from the DB
        /// </summary>
        /// <param name="type">user type string</param>
        public Task<List<User>> GetAllUsersByType(string type)
        {
            return context.Users.Where(x => x.Type == type).ToListAsync();
        }

        /// <summary>
        /// Gets all beers for a particular brewery using the brewery Id
        /// </summary>
        /// <param name="id">brewery id</param>
        public Task<List<Beer>> GetAllBeersByBreweryId(string id)
        {
            return context.Beers.Where(x => x.BreweryID == id).ToListAsync();
        }

        /// <summary>
        /// Gets all orders for a particular customer using the custoer Id
        /// </summary>
        /// <param name="id">user id</param>
        public Task<List<Order>> GetAllOrdersByCustomerId(string id)
        {
            return context.Orders.Where(x => x.UserID == id).Include(x => x.LineItems).ThenInclude(y => y.Beer).ToListAsync();
        }

        /// <summary>
        /// Gets all orders by brewery Id
        /// </summary>
        /// <param name="id">brewery id</param>
        public Task<List<Order>> GetAllOrdersByBreweryId(string id)
        {
            return context.Orders.Where(x => x.BreweryID == id).Include(x => x.LineItems).ThenInclude(y => y.Beer).ToListAsync();
        }
    }
}
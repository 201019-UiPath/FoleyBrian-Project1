using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public abstract class IDataRepo<TEntity>
    {
        public BrewCrewContext context;

        public IDataRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        public abstract Task<List<TEntity>> GetAll();
        public abstract Task<TEntity> GetById(string id);
        public abstract void Add(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);


        public Task<User> GetUserByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).Include("Orders").FirstAsync();
        }

        public Task<List<User>> GetAllUsersByType(string type)
        {
            return context.Users.Where(x => x.Type == type).ToListAsync();
        }

        public Task<List<Beer>> GetAllBeersByBreweryId(string id)
        {
            //Task<List
            return context.Beers.Where(x => x.BreweryID == id).ToListAsync();
        }

        public Task<List<Order>> GetAllOrdersByCustomerId(string id)
        {
            return context.Orders.Where(x => x.UserID == id).Include(x => x.LineItems).ThenInclude(y => y.Beer).ToListAsync();
        }
    }
}
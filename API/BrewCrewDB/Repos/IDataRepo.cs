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
            return context.Users.FirstAsync(x => x.Email == email);
        }

        public Task<List<User>> GetAllUsersByType(string type)
        {
            return context.Users.Where(x => x.Type == type).ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class BreweryManagerRepo: IDataRepo<BreweryManager>
    {
        public BrewCrewContext context;

        public BreweryManagerRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(BreweryManager entity)
        {
            context.BreweryManagers.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(BreweryManager entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<BreweryManager> Get(string id)
        {
            return context.BreweryManagers.SingleAsync(x => x.UserID == id);
        }

        public Task<List<BreweryManager>> GetAll()
        {
            return context.BreweryManagers.Select(x => x).ToListAsync();
        }

        public Task<List<BreweryManager>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(BreweryManager entity)
        {
            throw new NotImplementedException();
        }
    }
}

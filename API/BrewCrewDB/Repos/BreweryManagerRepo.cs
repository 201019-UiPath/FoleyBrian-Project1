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

        public BreweryManagerRepo(BrewCrewContext context) : base(context)
        {

        }


        override public void Add(BreweryManager entity)
        {
            context.BreweryManagers.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(BreweryManager entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        override public Task<BreweryManager> GetById(string id)
        {
            return context.BreweryManagers.SingleAsync(x => x.UserID == id);
        }

        override public Task<List<BreweryManager>> GetAll()
        {
            return context.BreweryManagers.Select(x => x).ToListAsync();
        }

        override public void Update(BreweryManager entity)
        {
            throw new NotImplementedException();
        }
    }
}

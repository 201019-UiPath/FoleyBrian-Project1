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

        override public void Delete(string id)
        {
            BreweryManager breweryManager = new BreweryManager {ID = id};
            context.Remove(breweryManager);
            context.SaveChanges();
        }

        override public Task<BreweryManager> GetById(string id)
        {
            return context.BreweryManagers.SingleAsync(x => x.UserID == id);
        }

        override public Task<List<BreweryManager>> GetAll()
        {
            return context.BreweryManagers.Select(x => x).Include("Users").ToListAsync();
        }

        override public void Update(BreweryManager entity)
        {
            throw new NotImplementedException();
        }
    }
}

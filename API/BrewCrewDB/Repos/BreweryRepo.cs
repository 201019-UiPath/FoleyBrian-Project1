using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos

{
    public class BreweryRepo: IDataRepo<Brewery>
    {
        public BreweryRepo(BrewCrewContext context) : base(context)
        {

        }

        override public void Add(Brewery entity)
        {
            context.Breweries.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(string id)
        {
            Brewery brewery = new Brewery {ID = id};
            context.Remove(brewery);
            context.SaveChanges();
        }

        override public Task<Brewery> GetById(string id)
        {
            return context.Breweries.Where(x => x.ID == id).Include("Beers").Include("Orders").Include("BreweryManagers").FirstAsync();
        }

        override public Task<List<Brewery>> GetAll()
        {
            return context.Breweries.Select(x => x).ToListAsync();
        }

        override public void Update(Brewery entity)
        {
            Brewery entityToUpdate = context.Breweries.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Address = entity.Address;
                entityToUpdate.City = entity.City;
                entityToUpdate.Name = entity.Name;
                entityToUpdate.State = entity.State;
                entityToUpdate.Zip = entity.Zip;
                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

    }
}

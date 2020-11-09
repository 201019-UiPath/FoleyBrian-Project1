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
        public BrewCrewContext context;

        public BreweryRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(Brewery entity)
        {
            context.Breweries.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(Brewery entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<Brewery> Get(string id)
        {
            return context.Breweries.SingleAsync(x => x.ID == id);
        }

        public Task<List<Brewery>> GetAll()
        {
            return context.Breweries.Select(x => x).ToListAsync();
        }

        public Task<List<Brewery>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(Brewery entity)
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

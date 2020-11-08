using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class BeerRepo : IDataRepo<Beer>
    {
        //Class Fields
        public BrewCrewContext context;

        //Constructor
        public BeerRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        public void Add(Beer entity)
        {
            context.Beers.AddAsync(entity);
            context.SaveChangesAsync();
        }

        public void Delete(Beer entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public Task<Beer> Get(string id)
        {
            return context.Beers.SingleAsync(x => x.ID == id);
        }

        public Task<List<Beer>> GetAll()
        {
            return context.Beers.Select(x => x).ToListAsync();
        }

        public void Update(Beer entity)
        {
            Beer entityToUpdate = context.Beers.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                entityToUpdate.ABV = entity.ABV;
                entityToUpdate.IBU = entity.IBU;
                entityToUpdate.Price = entity.Price;
                entityToUpdate.Type = entity.Type;
                context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

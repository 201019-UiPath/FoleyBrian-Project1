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
        public BeerRepo(BrewCrewContext context) : base(context)
        {

        }


        override public void Add(Beer entity)
        {
            context.Beers.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(string id)
        {
            Beer beer = new Beer {ID = id};
            context.Remove(beer);
            context.SaveChanges();
        }

        override public Task<Beer> GetById(string id)
        {
            return context.Beers.SingleAsync(x => x.ID == id);
        }

        override public Task<List<Beer>> GetAll()
        {
            return context.Beers.Select(x => x).ToListAsync();
        }

        override public void Update(Beer entity)
        {
            Beer entityToUpdate = context.Beers.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                entityToUpdate.ABV = entity.ABV;
                entityToUpdate.IBU = entity.IBU;
                entityToUpdate.Price = entity.Price;
                entityToUpdate.Type = entity.Type;
                entityToUpdate.Keg = entity.Keg;
                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class BeerItemRepo : IDataRepo<BeerItem>
    {

        public BrewCrewContext context;


        public BeerItemRepo(BrewCrewContext context)
        {
            this.context = context;
        }



        public void Add(BeerItem entity)
        {
            context.BeerItems.AddAsync(entity);
            context.SaveChangesAsync();
        }

        public void Delete(BeerItem entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public Task<BeerItem> Get(string id)
        {
            return context.BeerItems.SingleAsync(x => x.ID == id);
        }

        public Task<List<BeerItem>> GetAll()
        {
            return context.BeerItems.Select(x => x).ToListAsync();
        }

        public void Update(BeerItem entity)
        {
            BeerItem entityToUpdate = context.BeerItems.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Keg = entity.Keg;
                context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

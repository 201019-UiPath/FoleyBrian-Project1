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
            context.SaveChanges();
        }

        public void Delete(BeerItem entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<BeerItem> Get(string id)
        {
            return context.BeerItems.SingleAsync(x => x.BeerID == id);
        }

        public Task<List<BeerItem>> GetAll()
        {
            return context.BeerItems.Select(x => x).ToListAsync();
        }

        public Task<List<BeerItem>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(BeerItem entity)
        {
            BeerItem entityToUpdate = context.BeerItems.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
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

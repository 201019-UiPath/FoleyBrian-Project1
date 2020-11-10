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

        public BeerItemRepo(BrewCrewContext context): base(context)
        {

        }

        override public void Add(BeerItem entity)
        {
            context.BeerItems.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(BeerItem entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        override public Task<BeerItem> GetById(string id)
        {
            return context.BeerItems.SingleAsync(x => x.BeerID == id);
        }

        override public Task<List<BeerItem>> GetAll()
        {
            return context.BeerItems.Select(x => x).ToListAsync();
        }

        override public void Update(BeerItem entity)
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

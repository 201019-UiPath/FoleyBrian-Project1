using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class LineItemRepo: IDataRepo<LineItem>
    {
        public BrewCrewContext context;

        public LineItemRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(LineItem entity)
        {
            context.LineItems.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(LineItem entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<LineItem> Get(string id)
        {
            return context.LineItems.SingleAsync(x => x.BeerID == id);
        }

        public Task<List<LineItem>> GetAll()
        {
            return context.LineItems.Select(x => x).ToListAsync();
        }

        public Task<List<LineItem>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(LineItem entity)
        {
            throw new NotImplementedException();
        }
    }
}

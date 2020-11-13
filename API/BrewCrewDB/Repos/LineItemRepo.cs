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
        public LineItemRepo(BrewCrewContext context) : base(context)
        {

        }


        override public void Add(LineItem entity)
        {
            context.LineItems.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(LineItem entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        override public Task<LineItem> GetById(string id)
        {
            return context.LineItems.SingleAsync(x => x.BeerID == id);
        }

        override public Task<List<LineItem>> GetAll()
        {
            return context.LineItems.Select(x => x).Include("Beer").ToListAsync();
        }

        override public void Update(LineItem entity)
        {
            throw new NotImplementedException();
        }

    }
}

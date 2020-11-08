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
        //Class Fields
        public BrewCrewContext context;

        //Constructor
        public LineItemRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        public void Add(LineItem entity)
        {
            context.LineItems.AddAsync(entity);
            context.SaveChangesAsync();
        }

        public void Delete(LineItem entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public Task<LineItem> Get(string id)
        {
            return context.LineItems.SingleAsync(x => x.ID == id);
        }

        public Task<List<LineItem>> GetAll()
        {
            return context.LineItems.Select(x => x).ToListAsync();
        }

        public void Update(LineItem entity)
        {
            throw new NotImplementedException();
        }
    }
}

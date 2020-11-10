using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class OrderRepo: IDataRepo<Order>
    {
        public OrderRepo(BrewCrewContext context) : base(context)
        {

        }


        override public void Add(Order entity)
        {
            context.Orders.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(Order entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        override public Task<Order> GetById(string id)
        {
            return context.Orders.SingleAsync(x => x.ID == id);
        }

        override public Task<List<Order>> GetAll()
        {
            return context.Orders.Select(x => x).ToListAsync();
        }

        override public void Update(Order entity)
        {
            Order entityToUpdate = context.Orders.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.TableNumber = entity.TableNumber;
                entityToUpdate.TotalPrice = entity.TotalPrice;
                entityToUpdate.Date = entity.Date;
                context.SaveChanges();
            } else
            {
                throw new Exception();
            }
        }
    }
}

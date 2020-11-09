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
        public BrewCrewContext context;

        public OrderRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(Order entity)
        {
            context.Orders.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<Order> Get(string id)
        {
            return context.Orders.SingleAsync(x => x.ID == id);
        }

        public Task<List<Order>> GetAll()
        {
            return context.Orders.Select(x => x).ToListAsync();
        }

        public Task<List<Order>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class CustomerRepo: IDataRepo<User>
    {
        //Class Fields
        public BrewCrewContext context;

        //Constructor
        public CustomerRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        public void Add(User entity)
        {
            context.Users.AddAsync(entity);
            context.SaveChangesAsync();
        }

        public void Delete(User entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public Task<User> Get(string id)
        {
            return context.Users.SingleAsync(x => x.ID == id);
        }

        public Task<List<User>> GetAll()
        {
            return context.Users.Where(x => x.Type == "customer").ToListAsync();
        }

        public void Update(User entity)
        {
            User entityToUpdate = context.Users.First(x => x.ID == entity.ID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Email = entity.Email;
                entityToUpdate.FName = entity.FName;
                entityToUpdate.LName = entity.LName;
                entityToUpdate.Password = entity.Password;
                context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class UserRepo: IDataRepo<User>
    {
        public BrewCrewContext context;

        public UserRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(User entity)
        {
            context.Users.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<User> Get(string id)
        {
            return context.Users.SingleAsync(x => x.ID == id);
        }

        public Task<List<User>> GetAll()
        {
            return context.Users.Select(x => x).ToListAsync();
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
                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public Task<List<User>> GetAllWhere(string identifier)
        {
            return context.Users.Where(x => x.Type == identifier).ToListAsync();
        }
    }
}

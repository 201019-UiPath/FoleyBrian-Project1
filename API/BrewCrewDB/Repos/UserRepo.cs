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
        public UserRepo(BrewCrewContext context) : base(context)
        {

        }


        override public void Add(User entity)
        {
            context.Users.AddAsync(entity);
            context.SaveChanges();
        }

        override public void Delete(string id)
        {
            User user = new User {ID = id};
            context.Remove(user);
            context.SaveChanges();
        }

        override public Task<User> GetById(string id)
        {
            return context.Users.Where(x => x.ID == id).Include("Orders").FirstOrDefaultAsync();
        }

        override public Task<List<User>> GetAll()
        {
            return context.Users.Select(x => x).Include("Orders").ToListAsync();
        }

        override public void Update(User entity)
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
    }
}

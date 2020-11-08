using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewCrewDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public class ManagersJointRepo: IDataRepo<ManagersJoint>
    {
        public BrewCrewContext context;

        public ManagersJointRepo(BrewCrewContext context)
        {
            this.context = context;
        }


        public void Add(ManagersJoint entity)
        {
            context.ManagersJoint.AddAsync(entity);
            context.SaveChanges();
        }

        public void Delete(ManagersJoint entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Task<ManagersJoint> Get(string id)
        {
            return context.ManagersJoint.SingleAsync(x => x.UserID == id);
        }

        public Task<List<ManagersJoint>> GetAll()
        {
            return context.ManagersJoint.Select(x => x).ToListAsync();
        }

        public Task<List<ManagersJoint>> GetAllWhere(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Update(ManagersJoint entity)
        {
            throw new NotImplementedException();
        }
    }
}

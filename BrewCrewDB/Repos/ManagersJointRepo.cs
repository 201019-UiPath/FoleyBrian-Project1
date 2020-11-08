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
        //Class Fields
        public BrewCrewContext context;

        //Constructor
        public ManagersJointRepo(BrewCrewContext context)
        {
            this.context = context;
        }

        public void Add(ManagersJoint entity)
        {
            context.ManagersJoint.AddAsync(entity);
            context.SaveChangesAsync();
        }

        public void Delete(ManagersJoint entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public Task<ManagersJoint> Get(string id)
        {
            return context.ManagersJoint.SingleAsync(x => x.ID == id);
        }

        public Task<List<ManagersJoint>> GetAll()
        {
            return context.ManagersJoint.Select(x => x).ToListAsync();
        }

        public void Update(ManagersJoint entity)
        {
            throw new NotImplementedException();
        }
    }
}

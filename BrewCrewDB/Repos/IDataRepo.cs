using BrewCrewDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrewCrewDB.Repos
{
    public interface IDataRepo<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(string id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
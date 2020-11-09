using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB.Repos;

namespace BrewCrewLib
{
    public class Service<T>: IService<T>
    {

        private readonly IDataRepo<T> _repo;

        public Service(IDataRepo<T> repo)
        {
            this._repo = repo;
            
        }

        public void AddResource(T entity)
        {
            _repo.Add(entity);
        }


        public void DeleteResource(T entity)
        {
            _repo.Delete(entity);
        }


        public T GetResource(string id)
        {
            return _repo.Get(id).Result;
        }


        public List<T> GetAllResources()
        {
            return _repo.GetAll().Result;
        }


        public void UpdateResource(T entity)
        {
            _repo.Update(entity);
        }

        public List<T> GetAllResources(string identifier)
        {
            return _repo.GetAllWhere(identifier).Result;
        }
    }
}

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


        public void DeleteResource(string id)
        {
            _repo.Delete(id);
        }


        public T GetResource(string id)
        {
            return _repo.GetById(id).Result;
        }


        public List<T> GetAllResources()
        {
            return _repo.GetAll().Result;
        }


        public void UpdateResource(T entity)
        {
            _repo.Update(entity);
        }


        //Type Specific Calls
        public User GetUserByEmail(string email)
        {
            return _repo.GetUserByEmail(email).Result;
        }

        public List<User> GetAllUsersByType(string type)
        {
            return _repo.GetAllUsersByType(type).Result;
        }

        public List<Beer> GetAllBeersByBreweryId(string id)
        {
            return _repo.GetAllBeersByBreweryId(id).Result;
        }

        public List<Order> GetAllOrdersByCustomerId(string id)
        {
            return _repo.GetAllOrdersByCustomerId(id).Result;
        }
    }
}

using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB.Repos;

namespace BrewCrewLib
{
    public class Service: IService
    {
        private readonly IDataRepo<Beer> _beerRepo;
        private readonly IDataRepo<Brewery> _breweryRepo;
        private readonly IDataRepo<LineItem> _lineItemRepo;
        private readonly IDataRepo<ManagersJoint> _managersJointRepo;
        private readonly IDataRepo<Order> _orderRepo;
        private readonly IDataRepo<User> _userRepo;
        private readonly IDataRepo<BeerItem> _beerItemRepo;

        public Service(IDataRepo<BeerItem> beerItemRepo, IDataRepo<Beer> beerRepo,
            IDataRepo<Brewery> breweryRepo, IDataRepo<LineItem> lineItemRepo,
            IDataRepo<ManagersJoint> managersJointRepo, IDataRepo<Order> orderRepo, IDataRepo<User> userRepo)
        {
            this._beerItemRepo = beerItemRepo;
            this._beerRepo = beerRepo;
            this._breweryRepo = breweryRepo;
            this._lineItemRepo = lineItemRepo;
            this._managersJointRepo = managersJointRepo;
            this._orderRepo = orderRepo;
            this._userRepo = userRepo;
        }

        //(C)RUD
        public void AddBeer(Beer entity)
        {
            _beerRepo.Add(entity);
        }

        public void AddBeerItem(BeerItem entity)
        {
            _beerItemRepo.Add(entity);
        }

        public void AddBrewery(Brewery entity)
        {
            _breweryRepo.Add(entity);
        }

        public void AddUser(User entity)
        {
            _userRepo.Add(entity);
        }

        public void AddLineItem(LineItem entity)
        {
            _lineItemRepo.Add(entity);
        }

        public void AddManagersJoint(ManagersJoint entity)
        {
            _managersJointRepo.Add(entity);
        }

        public void AddOrder(Order entity)
        {
            _orderRepo.Add(entity);
        }

        //CRU(D)
        public void DeleteBeer(Beer entity)
        {
            _beerRepo.Delete(entity);
        }

        public void DeleteBeerItem(BeerItem entity)
        {
            _beerItemRepo.Delete(entity);
        }

        public void DeleteBrewery(Brewery entity)
        {
            _breweryRepo.Delete(entity);
        }

        public void DeleteUser(User entity)
        {
            _userRepo.Delete(entity);
        }

        public void DeleteLineItem(LineItem entity)
        {
            _lineItemRepo.Delete(entity);
        }

        public void DeleteManagersJoint(ManagersJoint entity)
        {
            _managersJointRepo.Delete(entity);
        }

        public void DeleteOrder(Order entity)
        {
            _orderRepo.Delete(entity);
        }

        //C(R)UD
        public List<BeerItem> GetAllBeerItems()
        {
            return _beerItemRepo.GetAll().Result;
        }

        public List<Beer> GetAllBeers()
        {
            return _beerRepo.GetAll().Result;
        }

        public List<Brewery> GetAllBreweries()
        {
            return _breweryRepo.GetAll().Result;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll().Result;
        }

        public List<User> GetAllUsers(string identifier)
        {
            return _userRepo.GetAllWhere(identifier).Result;
        }

        public List<LineItem> GetAllLineItems()
        {
            return _lineItemRepo.GetAll().Result;
        }

        public List<ManagersJoint> GetAllManagersJoint()
        {
            return _managersJointRepo.GetAll().Result;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAll().Result;
        }

        public Beer GetBeer(string id)
        {
            return _beerRepo.Get(id).Result;
        }

        public BeerItem GetBeerItem(string id)
        {
            return _beerItemRepo.Get(id).Result;
        }

        public Brewery GetBrewery(string id)
        {
            return _breweryRepo.Get(id).Result;
        }

        public User GetUser(string id)
        {
            return _userRepo.Get(id).Result;
        }

        public LineItem GetLineItem(string id)
        {
            return _lineItemRepo.Get(id).Result;
        }

        public ManagersJoint GetManagersJoint(string id)
        {
            return _managersJointRepo.Get(id).Result;
        }

        public Order GetOrder(string id)
        {
            return _orderRepo.Get(id).Result;
        }

        //CR(U)D
        public void UpdateBeer(Beer entity)
        {
            _beerRepo.Update(entity);
        }

        public void UpdateBeerItem(BeerItem entity)
        {
            _beerItemRepo.Update(entity);
        }

        public void UpdateBrewery(Brewery entity)
        {
            _breweryRepo.Update(entity);
        }

        public void UpdateUser(User entity)
        {
            _userRepo.Update(entity);
        }

        public void UpdateLineItem(LineItem entity)
        {
            _lineItemRepo.Update(entity);
        }

        public void UpdateManagersJoint(ManagersJoint entity)
        {
            _managersJointRepo.Update(entity);
        }

        public void UpdateOrder(Order entity)
        {
            _orderRepo.Update(entity);
        }
    }
}

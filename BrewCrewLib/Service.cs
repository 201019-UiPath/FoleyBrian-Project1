using System;
using System.Collections.Generic;
using BrewCrewDB.Models;
using BrewCrewDB.Repos;

namespace BrewCrewLib
{
    public class Service: IService
    {
        //private readonly BeerItemRepo _beerItemRepo;
        private readonly IDataRepo<Beer> _beerRepo;
        private readonly IDataRepo<Brewery> _breweryRepo;
        private readonly IDataRepo<LineItem> _lineItemRepo;
        private readonly IDataRepo<ManagersJoint> _managersJointRepo;
        private readonly IDataRepo<Order> _orderRepo;
        private readonly IDataRepo<User> _customerRepo;
        private readonly IDataRepo<User> _managerRepo;
        private readonly IDataRepo<BeerItem> _beerItemRepo;

        public Service(IDataRepo<BeerItem> beerItemRepo, IDataRepo<Beer> beerRepo,
            IDataRepo<Brewery> breweryRepo, IDataRepo<LineItem> lineItemRepo,
            IDataRepo<ManagersJoint> managersJointRepo, IDataRepo<Order> orderRepo, IDataRepo<User> customerRepo,
            IDataRepo<User> managerRepo)
        {
            this._beerItemRepo = beerItemRepo;
            this._beerRepo = beerRepo;
            this._breweryRepo = breweryRepo;
            this._lineItemRepo = lineItemRepo;
            this._managersJointRepo = managersJointRepo;
            this._orderRepo = orderRepo;
            this._customerRepo = customerRepo;
            this._managerRepo = managerRepo;
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

        public void AddCustomer(User entity)
        {
            _customerRepo.Add(entity);
        }

        public void AddLineItem(LineItem entity)
        {
            _lineItemRepo.Add(entity);
        }

        public void AddManager(User entity)
        {
            _managerRepo.Add(entity);
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

        public void DeleteCustomer(User entity)
        {
            _customerRepo.Delete(entity);
        }

        public void DeleteLineItem(LineItem entity)
        {
            _lineItemRepo.Delete(entity);
        }

        public void DeleteManager(User entity)
        {
            _managerRepo.Delete(entity);
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
        public IEnumerable<BeerItem> GetAllBeerItems()
        {
            return _beerItemRepo.GetAll().Result;
        }

        public IEnumerable<Beer> GetAllBeers()
        {
            return _beerRepo.GetAll().Result;
        }

        public IEnumerable<Brewery> GetAllBreweries()
        {
            return _breweryRepo.GetAll().Result;
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return _customerRepo.GetAll().Result;
        }

        public IEnumerable<LineItem> GetAllLineItems()
        {
            return _lineItemRepo.GetAll().Result;
        }

        public IEnumerable<User> GetAllManagers()
        {
            return _managerRepo.GetAll().Result;
        }

        public IEnumerable<ManagersJoint> GetAllManagersJoint()
        {
            return _managersJointRepo.GetAll().Result;
        }

        public IEnumerable<Order> GetAllOrders()
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

        public User GetCustomer(string id)
        {
            return _customerRepo.Get(id).Result;
        }

        public LineItem GetLineItem(string id)
        {
            return _lineItemRepo.Get(id).Result;
        }

        public User GetManager(string id)
        {
            return _managerRepo.Get(id).Result;
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

        public void UpdateCustomer(User entity)
        {
            _customerRepo.Update(entity);
        }

        public void UpdateLineItem(LineItem entity)
        {
            _lineItemRepo.Update(entity);
        }

        public void UpdateManager(User entity)
        {
            _managerRepo.Update(entity);
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

//using BrewCrewDB.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace BrewCrewDB
//{
//    public class DBRepo : IAdminRepo, IManagerRepo, ICustomerRepo
//    {
//        //Class Fields
//        public BrewCrewContext context;

//        //Constructor
//        public DBRepo(BrewCrewContext context)
//        {
//            this.context = context;
//        }

//        ////Manager Data
//        //public void AddManagerAsync(ManagersJoint mj)
//        //{
//        //    context.ManagersJoint.AddAsync(mj);
//        //    context.SaveChangesAsync();
//        //}

//        //public Task<List<User>> GetAllManagersAsync()
//        //{
//        //    return context.Users.Where(x => x.Type == "Manager").ToListAsync();
//        //}

//        ////Brewery Data
//        //public void AddBreweryManagerAsync(ManagersJoint manager)
//        //{
//        //    context.ManagersJoint.AddAsync(manager);
//        //    context.SaveChangesAsync();
//        //}

//        ////public Task<List<Brewery>> GetAllBreweriesAsync()
//        ////{
//        ////    return context.Breweries.Select(x => x).ToListAsync();
//        ////}

//        //public List<Brewery> GetAllBreweriesAsync()
//        //{
//        //    return context.Breweries.Select(x => x).ToList();
//        //}

//        ////Beer Data
//        //public void AddBeerAsync(BeerItem beerItem)
//        //{
//        //    context.BeerItems.AddAsync(beerItem);
//        //    context.SaveChanges();
//        //}

//        //public Task<List<BeerItem>> GetAllBeersByBreweryIdAsync(string breweryId)
//        //{
//        //    return context.BeerItems.Where(x => x.BreweryID == breweryId).Include(b => b.Beer).ToListAsync();
//        //}

//        //public void UpdateBeer(Beer beer)
//        //{
//        //    context.Beers.Update(beer);
//        //    context.SaveChanges();
//        //}

//        //public Beer GetBeerByIdAsync(string beerId)
//        //{
//        //    return context.Beers.Single(x => x.ID == beerId);
//        //}

//        ////Customer Data
//        //public User GetCustomerByIdAsync(string customerId)
//        //{
//        //    return context.Users.Single(x => x.ID == customerId);
//        //}

//        //public void AddCustomerAsync(User user)
//        //{
//        //    context.Users.AddAsync(user);
//        //    context.SaveChanges();
//        //}

//        //public User GetUserByEmailAsync(string email)
//        //{
//        //    return context.Users.Single(x => x.Email == email);
//        //}


//        ////Order Data
//        //public void PlaceOrderAsync(Order order)
//        //{
//        //    context.Orders.AddAsync(order);
//        //    context.SaveChanges();
//        //}

//        //public Task<List<Order>> GetAllOrdersByBreweryIdAsync(string breweryId)
//        //{
//        //    return context.Orders.Where(x => x.BreweryID == breweryId).ToListAsync();
//        //}

//        //public Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId)
//        //{
//        //    return context.Orders.Where(x => x.UserID == customerId).Where(y => y.BreweryID == breweryId).Include("LineItems").ToListAsync();
//        //}

//        ////NEW ITEMS
//        //public Brewery GetBreweryById(string breweryId)
//        //{
//        //    return context.Breweries.Single(x => x.ID == breweryId);
//        //}

//        //public void DeleteBreweryById(string breweryId)
//        //{
//        //    Brewery brewery = new Brewery() { ID = breweryId };
//        //    context.Breweries.Attach(brewery);
//        //    context.Breweries.Remove(brewery);
//        //    context.SaveChanges();
//        //}
//        //public void DeleteManagerById(string managerId)
//        //{
//        //    User manager = new User() { ID = managerId };
//        //    context.Users.Attach(manager);
//        //    context.Users.Remove(manager);
//        //    context.SaveChanges();
//        //}

//        //public void DeleteCustomerById(string customerId)
//        //{
//        //    User customer = new User() { ID = customerId };
//        //    context.Users.Attach(customer);
//        //    context.Users.Remove(customer);
//        //    context.SaveChanges();
//        //}

//        //public Brewery GetBreweryByManagerId(string managerId)
//        //{
//        //    ManagersJoint managersJoint = context.ManagersJoint.Single(b => b.UserID == managerId);
//        //    return context.Breweries.Single(b => b.ID == managersJoint.ID);
//        //}

//    }
//}
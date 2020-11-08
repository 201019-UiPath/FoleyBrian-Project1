//using BrewCrewDB.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace BrewCrewDB
//{
//    /// <summary>
//    /// Repository handling all Customer operations on the database
//    /// </summary>
//    public interface ICustomerRepo
//    {
//        // /// <summary>
//        ///// Customer Data
//        ///// </summary>
//        ///// <param name="customer">Single customer is added to the DB</param>
//        //void AddCustomerAsync(User user);

//        ///// <param name="email">Single customer is returned matched on email</param>
//        //User GetUserByEmailAsync(string email);

//        // /// <summary>
//        ///// Order Data
//        ///// </summary>
//        ///// <param name="order">Order to add to DB</param>
//        //void PlaceOrderAsync(Order order);

//        ///// <param name="order" name="breweryId">List of orders returned matched on customerId and breweryId</param>
//        //Task<List<Order>> GetAllOrdersByCustomerBreweryIdAsync(string customerId, string breweryId);

//        // /// <summary>
//        ///// Beer Data
//        ///// </summary>

//        ///// <param name="Beer">Beer to be updated</param>
//        //void UpdateBeer(Beer beer);

//        ///// <param name="breweryId">List of beers is returned matched on brewery Id</param>
//        //Task<List<BeerItem>> GetAllBeersByBreweryIdAsync(string breweryId);

//        ///// <param name="beerId">Single beer is returned matched on Beer Id</param>
//        //Beer GetBeerByIdAsync(string beerId);

//        // /// <summary>
//        ///// Brewery Data
//        ///// </summary>
//        ///// <returns>List of All Breweries in DB table returned</returns>
//        //List<Brewery> GetAllBreweriesAsync();

//        ////NEW ITEMS
//        //void DeleteCustomerById(string customerId);
//        //


//        //Need these Cruds
//        void AddOrder(Order entity);
        

//        void DeleteOrder(Order entity);
       

//        Order GetOrder(string id);
       

//        IEnumerable<Order> GetAllOrders();


//        public void AddLineItem(LineItem entity);


//        public void DeleteLineItem(LineItem entity);


//        public LineItem GetLineItem(string id);


//        public IEnumerable<LineItem> GetAllLineItems();

//        public void AddCustomer(User entity);


//        public void DeleteCustomer(User entity);


//        public User GetCustomer(string id);


//        public IEnumerable<User> GetAllCustomers();


//        public void UpdateCustomer(User entity);

//        public Brewery GetBrewery(string id);


//        public IEnumerable<Brewery> GetAllBreweries();

//        public Beer GetBeer(string id);

//        public IEnumerable<Beer> GetAllBeers();

//    }
//}
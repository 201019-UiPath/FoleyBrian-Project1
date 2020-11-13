using System;
using Xunit;
using BrewCrewLib;
using BrewCrewDB.Models;
using BrewCrewDB;
using BrewCrewDB.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewCrewTest
{
    public class DBTest
    {
        //IDataRepo<BeerItem> _beerItemRepo;
        IDataRepo<Beer> _beerRepo;
        IDataRepo<BreweryManager> _breweryManagerRepo;
        IDataRepo<Brewery> _breweryRepo;
        IDataRepo<LineItem> _lineItemRepo;
        IDataRepo<Order> _orderRepo;
        IDataRepo<User> _userRepo;

        private readonly User TestCustomer = new User()
        {
            ID = "1",
            FName = "Michael",
            LName = "Scott",
            Email = "customer1@email.net",
            Password = "qqqqqq"
        };
        private readonly User TestManager = new User()
        {
            ID = "2",
            FName = "Dwight",
            LName = "Schrute",
            Email = "manager1@email.net",
            Password = "qqqqqq",
        };
        private readonly Brewery TestBrewery = new Brewery()
        {
            ID = "1",
            Name = "Lewis and Clark Brewery",
            State = "MT",
            City = "Helena",
            Address = "123 Beer Ave",
            Zip = 12345
        };

        private readonly Beer TestBeer = new Beer()
        {
            ID = "1",
            Name = "White Stout",
            Type = "Stout",
            ABV = 9.5,
            IBU = 44,
        };

        private readonly Order TestOrder = new Order()
        {
            ID = "1",
            Date = DateTime.Now,
            TableNumber = 1,
            TotalPrice = 4.00
        };

        //private readonly BeerItem TestBeerItem = new BeerItem()
        //{
        //    ID = "1",
        //    BreweryID = "1",
        //    BeerID = "1",
        //    Keg = 100
        //};

        private readonly BreweryManager TestBreweryManager = new BreweryManager()
        {
            ID = "1",
            BreweryID = "1",
            UserID = "1"
        };

        private readonly LineItem TestLineItem = new LineItem()
        {
            ID = "1",
            OrderID = "1",
            BeerID = "1",
        };

        private readonly List<User> TestUsers = new List<User>()
        {
            new User()
            {
                ID = "3",
                FName = "Michael",
                LName = "Scott",
                Email = "manager1@email.net",
                Password = "qqqqqq",
            },

            new User()
            {
                ID = "4",
                FName = "Dwight",
                LName = "Schrute",
                Email = "customer1@email.net",
                Password = "qqqqqq",
            }
        };

        private readonly List<Brewery> TestBreweries = new List<Brewery>()
        {
            new Brewery()
            {
                ID = "2",
                Name = "Lewis and Clark Brewery",
                State = "MT",
                City = "Helena",
                Address = "123 Beer Ave",
                Zip = 12345
            },

            new Brewery()
            {
                ID = "3",
                Name = "Missouri River Brewing Co",
                State = "MT",
                City = "East Helena",
                Address = "123 Stout Ave",
                Zip = 12345
            }
        };

        private readonly List<Beer> TestBeers = new List<Beer>()
        {
            new Beer()
            {
                ID = "2",
                Name = "Vanilla Creamsickle",
                Type = "Ale",
                ABV = 9.5,
                IBU = 44,
            },

            new Beer()
            {
                ID = "3",
                Name = "Miners Gold",
                Type = "Stout",
                ABV = 9.5,
                IBU = 33,
            }
        };

        private readonly List<Order> TestOrders = new List<Order>()
        {
            new Order()
            {
                ID = "2",
                Date = DateTime.Now,
                TableNumber = 1,
            },

            new Order()
            {
                ID = "3",
                Date = DateTime.Now,
                TableNumber = 2,
            }
        };

        //private readonly List<BeerItem> TestBeerItems = new List<BeerItem>()
        //{
        //    new BeerItem()
        //    {
        //    ID = "2",
        //    BreweryID = "1",
        //    BeerID = "1",
        //    Keg = 100
        //    },

        //    new BeerItem()
        //    {
        //    ID = "3",
        //    BreweryID = "1",
        //    BeerID = "1",
        //    Keg = 100
        //    }
        //};

        private readonly List<BreweryManager> TestBreweryManagers = new List<BreweryManager>()
        {
            new BreweryManager()
            {
                ID = "2",
                BreweryID = "1",
                UserID = "1"
            },

            new BreweryManager()
            {
                ID = "3",
                BreweryID = "1",
                UserID = "1"
            }

        };

        private readonly List<LineItem> TestLineItems = new List<LineItem>()
        {
            new LineItem()
            {
                ID = "2",
                OrderID = "1",
                BeerID = "1",
            },

            new LineItem()
            {
                ID = "3",
                OrderID = "1",
                BeerID = "1",
            }

        };


        private void Seed(BrewCrewContext testContext)
        {
            testContext.Users.AddRange(TestUsers);
            testContext.Breweries.AddRange(TestBreweries);
            testContext.Beers.AddRange(TestBeers);
            testContext.Orders.AddRange(TestOrders);
            testContext.LineItems.AddRange(TestLineItems);
            testContext.BreweryManagers.AddRange(TestBreweryManagers);
            //testContext.BeerItems.AddRange(TestBeerItems);
            testContext.SaveChanges();
        }

        [Fact]
        public void TestAddCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddCustomer").Options;
            using var testContext = new BrewCrewContext(options);
            _userRepo = new UserRepo(testContext);

            //Act
            _userRepo.Add(TestCustomer);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Users.SingleAsync(c => c.Type == TestCustomer.Type));
        }

        [Fact]
        public void TestAddManager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddManager").Options;
            using var testContext = new BrewCrewContext(options);
            _userRepo = new UserRepo(testContext);

            //Act
            _userRepo.Add(TestManager);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Users.SingleAsync(c => c.Type == TestManager.Type));
        }

        [Fact]
        public void TestAddBeer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddBeer").Options;
            using var testContext = new BrewCrewContext(options);
            _beerRepo = new BeerRepo(testContext);

            //Act
            _beerRepo.Add(TestBeer);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Beers.SingleAsync(c => c.ID == TestBeer.ID));
        }

        [Fact]
        public void TestAddOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddOrder").Options;
            using var testContext = new BrewCrewContext(options);
            _orderRepo = new OrderRepo(testContext);

            //Act
            _orderRepo.Add(TestOrder);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Orders.SingleAsync(c => c.ID == TestOrder.ID));
        }

        [Fact]
        public void TestAddBrewery()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddBrewery").Options;
            using var testContext = new BrewCrewContext(options);
            _breweryRepo = new BreweryRepo(testContext);

            //Act
            _breweryRepo.Add(TestBrewery);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Breweries.SingleAsync(c => c.ID == TestBrewery.ID));
        }

        //[Fact]
        //public void TestAddBeerItem()
        //{
        //    //Arrange
        //    var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddBeerItem").Options;
        //    using var testContext = new BrewCrewContext(options);
        //    _beerItemRepo = new BeerItemRepo(testContext);

        //    //Act
        //    _beerItemRepo.Add(TestBeerItem);

        //    //Assert
        //    using var assertContext = new BrewCrewContext(options);
        //    Assert.NotNull(assertContext.Breweries.SingleAsync(c => c.ID == TestBeerItem.ID));
        //}

        [Fact]
        public void TestAddLineItem()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddLineItem").Options;
            using var testContext = new BrewCrewContext(options);
            _lineItemRepo = new LineItemRepo(testContext);

            //Act
            _lineItemRepo.Add(TestLineItem);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.LineItems.SingleAsync(c => c.ID == TestLineItem.ID));
        }

        [Fact]
        public void TestAddBreweryManager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestAddBreweryManager").Options;
            using var testContext = new BrewCrewContext(options);
            _breweryManagerRepo = new BreweryManagerRepo(testContext);

            //Act
            _breweryManagerRepo.Add(TestBreweryManager);

            //Assert
            using var assertContext = new BrewCrewContext(options);
            Assert.NotNull(assertContext.Breweries.SingleAsync(c => c.ID == TestBreweryManager.ID));
        }

        [Fact]
        public void TestGetUsers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetUsers").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _userRepo = new UserRepo(assertContext);
            var result = _userRepo.GetAll();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetBreweries()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBreweries").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _breweryRepo = new BreweryRepo(assertContext);
            var result = _breweryRepo.GetAll();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetBeers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBeers").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _beerRepo = new BeerRepo(assertContext);
            var result = _beerRepo.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetOrders()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetOrders").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _orderRepo = new OrderRepo(assertContext);
            var result = _orderRepo.GetAll();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        //[Fact]
        //public void TestGetBeerItems()
        //{
        //    //Arrange
        //    var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBeerItems").Options;
        //    using var testContext = new BrewCrewContext(options);

        //    Seed(testContext);

        //    //Act
        //    using var assertContext = new BrewCrewContext(options);
        //    _beerItemRepo = new BeerItemRepo(assertContext);
        //    var result = _beerItemRepo.GetAll();

        //    //Assert
        //    Assert.NotNull(result.Result);
        //    Assert.Equal(2, result.Result.Count);
        //}

        [Fact]
        public void TestGetLineItems()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetLineItems").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _lineItemRepo = new LineItemRepo(assertContext);
            var result = _lineItemRepo.GetAll();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetBreweryManagers()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetOrders").Options;
            using var testContext = new BrewCrewContext(options);

            //Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _breweryManagerRepo = new BreweryManagerRepo(assertContext);
            var result = _breweryManagerRepo.GetAll();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(2, result.Result.Count);
        }

        [Fact]
        public void TestGetUserByEmail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetAllUsersWhere").Options;
            using var testContext = new BrewCrewContext(options);

            //Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _userRepo = new UserRepo(assertContext);
            var result = _userRepo.GetUserByEmail("customer1@email.net");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("customer1@email.net", result.Result.Email);
        }

        [Fact]
        public void TestGetAllUsersByType()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetAllUsersWhere").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _userRepo = new UserRepo(assertContext);
            var result = _userRepo.GetAllUsersByType("customer");

            //Assert
            Assert.NotNull(result);
            foreach(var user in result.Result)
            {
               Assert.Equal("customer", user.Type);
            }
        }

        [Fact]
        public void TestGetBreweryById()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBreweryById").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _breweryRepo = new BreweryRepo(assertContext);
            Brewery result = _breweryRepo.GetById("2").Result;

            //Assert
            Assert.NotNull(assertContext.Breweries.SingleAsync(c => c.ID == result.ID));
        }

        [Fact]
        public void TestGetBeerById()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetBeerById").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _beerRepo = new BeerRepo(assertContext);
            Task<Beer> result = _beerRepo.GetById("2");

            //Assert
            Assert.NotNull(assertContext.Beers.SingleAsync(c => c.ID == result.Result.ID));
        }

        [Fact]
        public void TestGetOrderById()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BrewCrewContext>().UseInMemoryDatabase("TestGetOrderById").Options;
            using var testContext = new BrewCrewContext(options);

            Seed(testContext);

            //Act
            using var assertContext = new BrewCrewContext(options);
            _orderRepo = new OrderRepo(assertContext);
            var result = _orderRepo.GetById("2");

            //Assert
            Assert.NotNull(assertContext.Orders.SingleAsync(c => c.ID == result.Result.ID));
        }
    }
}

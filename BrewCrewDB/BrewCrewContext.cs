using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BrewCrewDB.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;


namespace BrewCrewDB
{
    public class BrewCrewContext: DbContext
    {
        public DbSet<Beer> Beers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<BeerItem> BeerItems {get;set;}
        public DbSet<ManagersJoint> ManagersJoint {get;set;}
        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<LineItem> LineItems {get;set;}
        public DbSet<Admin> Admins { get; set; }

        public BrewCrewContext(DbContextOptions<BrewCrewContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin()
                {
                    ID = Guid.NewGuid().ToString(),
                    username = "admin",
                    password = "password"
                }
            );

            //Can delete this below when UI is setup
            modelBuilder.Entity<Brewery>().HasData(
                    new Brewery()
                    {
                        ID = "1",
                        Name = "Brewery",
                        State = "MT",
                        City = "Helena",
                        Address = "123 Beer Lane",
                        Zip = "12345",
                    }
            );

            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        ID = "1",
                        FName = "John",
                        LName = "Smith",
                        Email = "manager1@email.net",
                        Password = "password",
                        Type = "manager",
                    }
            );

            modelBuilder.Entity<ManagersJoint>().HasData(
                    new ManagersJoint()
                    {
                        ID = "1",
                        BreweryID = "1",
                        UserID = "1",
                    }
            );

            /*
            modelBuilder.Entity<User>().HasData(
                    new ManagersJoint()
                    {
                        ID = "1",
                        BreweryID = "1",
                        UserID = "1",
                    }
            );



            
            BeerItems = new List<BeerItems>()
                            {
                                new BeerItems()
                                {
                                    ID = "1",
                                    BreweryID = "1",
                                    BeerID = "1",
                                    Keg = "100",
                                    Beer = new Beer()
                                    {
                                        ID = "1",
                                        Name = "Beer",
                                        Type = "Type",
                                        ABV = "ABV",
                                        IBU = "IBU",
                                        Price = "4.00"
                                    }
                                }
                            }

                        },
                        User = 
                            Orders = new List<Order>()
                            {
                                new Order()
                                {
                                    ID = "1",
                                    UserID = "1",
                                    BreweryID = "1",
                                    Date = DateTime.Now,
                                    TableNumber = "3",
                                    TotalPrice = "4.00",
                                    LineItems = new List<LineItems>()
                                    {
                                        new LineItems()
                                        {
                                            ID = "1",
                                            OrderID = "1",
                                            BeerID = "1"
                                        }
                                    }
                                }
                            }
                        }
                    }
                */
        }
    }
}
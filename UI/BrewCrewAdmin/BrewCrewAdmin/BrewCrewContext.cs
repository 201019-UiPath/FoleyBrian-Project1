using Microsoft.EntityFrameworkCore;
using BrewCrewAdmin.Models;
using System;



namespace BrewCrewDB
{
    public class BrewCrewContext : DbContext
    {

        public DbSet<Beer> Beers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BeerItem> BeerItems { get; set; }
        public DbSet<BreweryManager> BreweryManagers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        public BrewCrewContext(DbContextOptions<BrewCrewContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<Beer>().Property(x => x.ID).HasDefaultValue(Guid.NewGuid().ToString()).ValueGeneratedOnAdd();
        //    //modelBuilder.Entity<Admin>().Property(x => x.ID).HasDefaultValue(Guid.NewGuid().ToString()).ValueGeneratedOnAdd();


        //    modelBuilder.Entity<Admin>().HasData(
        //        new Admin()
        //        {
        //            ID = "1",
        //            username = "admin",
        //            password = "password"
        //        }
        //    );

        //    //Can delete this below when UI is setup
        //    modelBuilder.Entity<Brewery>().HasData(
        //            new Brewery()
        //            {
        //                ID = "1",
        //                Name = "Brewery",
        //                State = "MT",
        //                City = "Helena",
        //                Address = "123 Beer Lane",
        //                Zip = 12345
        //            }
        //    );

        //    modelBuilder.Entity<User>().HasData(
        //            new User()
        //            {
        //                ID = "1",
        //                FName = "John",
        //                LName = "Smith",
        //                Email = "manager1@email.net",
        //                Password = "password",
        //                Type = "manager"
        //            }
        //    );

        //    modelBuilder.Entity<BreweryManager>().HasData(
        //            new BreweryManager()
        //            {
        //                ID = "1",
        //                BreweryID = "1",
        //                UserID = "1"
        //            }
        //    );


        //    modelBuilder.Entity<User>().HasData(
        //            new User()
        //            {
        //                ID = "2",
        //                FName = "Jane",
        //                LName = "Smith",
        //                Email = "customer1@email.net",
        //                Password = "password",
        //                Type = "customer"
        //            }
        //    );

        //    modelBuilder.Entity<Beer>().HasData(
        //            new Beer()
        //            {
        //                ID = "1",
        //                Name = "Beer",
        //                ABV = 9.2,
        //                IBU = 33,
        //                Price = 4.00,
        //                Type = "stout"
        //            }
        //    );

        //    modelBuilder.Entity<BeerItem>().HasData(
        //            new BeerItem()
        //            {
        //                ID = "1",
        //                BreweryID = "1",
        //                BeerID = "1",
        //                Keg = 100
        //            }
        //    );

        //    modelBuilder.Entity<Order>().HasData(
        //            new Order()
        //            {
        //                ID = "1",
        //                UserID = "1",
        //                BreweryID = "1",
        //                Date = DateTime.Now,
        //                TableNumber = 3,
        //                TotalPrice = 4.00
        //            }
        //    );

        //    modelBuilder.Entity<LineItem>().HasData(
        //            new LineItem()
        //            {
        //                ID = "1",
        //                OrderID = "1",
        //                BeerID = "1"
        //            }
        //    );
        //}
    }
}
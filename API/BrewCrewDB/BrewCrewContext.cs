using Microsoft.EntityFrameworkCore;
using BrewCrewDB.Models;
using System;



namespace BrewCrewDB
{
    public class BrewCrewContext: DbContext
    {
        
        public DbSet<Beer> Beers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<BreweryManager> BreweryManagers {get;set;}
        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<LineItem> LineItems {get;set;}
        public DbSet<Admin> Admins { get; set; }

        public BrewCrewContext(DbContextOptions<BrewCrewContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Beer>().Property(x => x.ID).HasDefaultValue(Guid.NewGuid().ToString()).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Admin>().Property(x => x.ID).HasDefaultValue(Guid.NewGuid().ToString()).ValueGeneratedOnAdd();
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            string guid3 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Admin>().HasData(
                new Admin()
                {
                    ID = "1",
                    username = "admin",
                    password = "password"
                }
            );

            //Can delete this below when UI is setup
            modelBuilder.Entity<Brewery>().HasData(
                    new Brewery()
                    {
                        ID = guid1,
                        Name = "Missouri River Brewing Company",
                        State = "MT",
                        City = "East Helena",
                        Address = "123 Beer Lane",
                        Zip = 12345
                    }
            );


            modelBuilder.Entity<Brewery>().HasData(
                    new Brewery()
                    {
                        ID = guid2,
                        Name = "Lewis and Clark Brewery",
                        State = "MT",
                        City = "Helena",
                        Address = "123 Stout Lane",
                        Zip = 12345
                    }
            );

            modelBuilder.Entity<Brewery>().HasData(
                    new Brewery()
                    {
                        ID = guid3,
                        Name = "Bridger Brewing",
                        State = "MT",
                        City = "Helena",
                        Address = "123 Ale Lane",
                        Zip = 12345
                    }
            );

            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        ID = "1",
                        FName = "Michael",
                        LName = "Scott",
                        Email = "manager1@email.net",
                        Password = "password",
                        Type = "manager"
                    }
            );

            modelBuilder.Entity<BreweryManager>().HasData(
                    new BreweryManager()
                    {
                        ID = "1",
                        BreweryID = guid1,
                        UserID = "1"
                    }
            );


            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        ID = "2",
                        FName = "Dwight",
                        LName = "Schrute",
                        Email = "manager2@email.net",
                        Password = "password",
                        Type = "manager"
                    }
            );

            modelBuilder.Entity<BreweryManager>().HasData(
                    new BreweryManager()
                    {
                        ID = "2",
                        BreweryID = guid2,
                        UserID = "2"
                    }
            );

            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        ID = "3",
                        FName = "Jim",
                        LName = "Halpert",
                        Email = "manager3@email.net",
                        Password = "password",
                        Type = "manager"
                    }
            );

            modelBuilder.Entity<BreweryManager>().HasData(
                    new BreweryManager()
                    {
                        ID = "3",
                        BreweryID = guid3,
                        UserID = "3"
                    }
            );

            modelBuilder.Entity<Beer>().HasData(
                    new Beer()
                    {
                        ID = "1",
                        Name = "Beer",
                        ABV = 9.2,
                        IBU = 33,
                        Price = 4.00,
                        Type = "stout",
                        BreweryID = guid1,
                        Keg = 100
                    }
            );
        }
    }
}
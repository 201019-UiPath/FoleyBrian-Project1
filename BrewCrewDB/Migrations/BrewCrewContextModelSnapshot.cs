﻿// <auto-generated />
using System;
using BrewCrewDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BrewCrewDB.Migrations
{
    [DbContext(typeof(BrewCrewContext))]
    partial class BrewCrewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BrewCrewDB.Models.Admin", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            ID = "5426b72a-185d-45a3-91bb-89dc4153f083",
                            password = "password",
                            username = "admin"
                        });
                });

            modelBuilder.Entity("BrewCrewDB.Models.Beer", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("ABV")
                        .HasColumnType("text");

                    b.Property<string>("IBU")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BrewCrewDB.Models.BeerItem", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("BeerID")
                        .HasColumnType("text");

                    b.Property<string>("BreweryID")
                        .HasColumnType("text");

                    b.Property<string>("Keg")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BeerID");

                    b.HasIndex("BreweryID");

                    b.ToTable("BeerItems");
                });

            modelBuilder.Entity("BrewCrewDB.Models.Brewery", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            ID = "1",
                            Address = "123 Beer Lane",
                            City = "Helena",
                            Name = "Brewery",
                            State = "MT",
                            Zip = "12345"
                        });
                });

            modelBuilder.Entity("BrewCrewDB.Models.LineItem", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("BeerID")
                        .HasColumnType("text");

                    b.Property<string>("OrderID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BeerID");

                    b.HasIndex("OrderID");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("BrewCrewDB.Models.ManagersJoint", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("BreweryID")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BreweryID");

                    b.HasIndex("UserID");

                    b.ToTable("ManagersJoint");

                    b.HasData(
                        new
                        {
                            ID = "1",
                            BreweryID = "1",
                            UserID = "1"
                        });
                });

            modelBuilder.Entity("BrewCrewDB.Models.Order", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("BreweryID")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TableNumber")
                        .HasColumnType("text");

                    b.Property<string>("TotalPrice")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BreweryID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BrewCrewDB.Models.User", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FName")
                        .HasColumnType("text");

                    b.Property<string>("LName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = "1",
                            Email = "manager1@email.net",
                            FName = "John",
                            LName = "Smith",
                            Password = "password",
                            Type = "manager"
                        });
                });

            modelBuilder.Entity("BrewCrewDB.Models.BeerItem", b =>
                {
                    b.HasOne("BrewCrewDB.Models.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerID");

                    b.HasOne("BrewCrewDB.Models.Brewery", "brewery")
                        .WithMany("BeerItems")
                        .HasForeignKey("BreweryID");
                });

            modelBuilder.Entity("BrewCrewDB.Models.LineItem", b =>
                {
                    b.HasOne("BrewCrewDB.Models.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerID");

                    b.HasOne("BrewCrewDB.Models.Order", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderID");
                });

            modelBuilder.Entity("BrewCrewDB.Models.ManagersJoint", b =>
                {
                    b.HasOne("BrewCrewDB.Models.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryID");

                    b.HasOne("BrewCrewDB.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("BrewCrewDB.Models.Order", b =>
                {
                    b.HasOne("BrewCrewDB.Models.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryID");

                    b.HasOne("BrewCrewDB.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}

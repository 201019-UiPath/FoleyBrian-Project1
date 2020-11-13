using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrewCrewDB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ABV = table.Column<double>(nullable: false),
                    IBU = table.Column<short>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BreweryID = table.Column<string>(nullable: true),
                    Keg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreweryManagers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    BreweryID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreweryManagers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BreweryManagers_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreweryManagers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    BreweryID = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TableNumber = table.Column<short>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    OrderID = table.Column<string>(nullable: true),
                    BeerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LineItems_Beers_BeerID",
                        column: x => x.BeerID,
                        principalTable: "Beers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "password", "username" },
                values: new object[] { "1", "password", "admin" });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "ID", "Address", "City", "Name", "State", "Zip" },
                values: new object[,]
                {
                    { "42e1c629-ceb9-44d7-a555-e16a30232b4a", "123 Beer Lane", "East Helena", "Missouri River Brewing Company", "MT", (short)12345 },
                    { "d831ea52-a9cc-4f3b-adcd-c2890809a247", "123 Stout Lane", "Helena", "Lewis and Clark Brewery", "MT", (short)12345 },
                    { "30042111-ab04-4f86-9ecd-cdb342276b65", "123 Ale Lane", "Helena", "Bridger Brewing", "MT", (short)12345 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "FName", "LName", "Password", "Type" },
                values: new object[,]
                {
                    { "1", "manager1@email.net", "Michael", "Scott", "password", "manager" },
                    { "2", "manager2@email.net", "Dwight", "Schrute", "password", "manager" },
                    { "3", "manager3@email.net", "Jim", "Halpert", "password", "manager" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "ID", "ABV", "BreweryID", "IBU", "Keg", "Name", "Price", "Type" },
                values: new object[] { "1", 9.1999999999999993, "42e1c629-ceb9-44d7-a555-e16a30232b4a", (short)33, 100, "Beer", 4.0, "stout" });

            migrationBuilder.InsertData(
                table: "BreweryManagers",
                columns: new[] { "ID", "BreweryID", "UserID" },
                values: new object[,]
                {
                    { "1", "42e1c629-ceb9-44d7-a555-e16a30232b4a", "1" },
                    { "2", "d831ea52-a9cc-4f3b-adcd-c2890809a247", "2" },
                    { "3", "30042111-ab04-4f86-9ecd-cdb342276b65", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryID",
                table: "Beers",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_BreweryManagers_BreweryID",
                table: "BreweryManagers",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_BreweryManagers_UserID",
                table: "BreweryManagers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_BeerID",
                table: "LineItems",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrderID",
                table: "LineItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BreweryID",
                table: "Orders",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "BreweryManagers");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

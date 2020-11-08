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
                name: "Beers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ABV = table.Column<string>(nullable: true),
                    IBU = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.ID);
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
                    Zip = table.Column<string>(nullable: true)
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
                name: "BeerItems",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    BreweryID = table.Column<string>(nullable: true),
                    BeerID = table.Column<string>(nullable: true),
                    Keg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BeerItems_Beers_BeerID",
                        column: x => x.BeerID,
                        principalTable: "Beers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeerItems_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagersJoint",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    BreweryID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagersJoint", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ManagersJoint_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagersJoint_Users_UserID",
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
                    TableNumber = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<string>(nullable: true)
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
                values: new object[] { "5426b72a-185d-45a3-91bb-89dc4153f083", "password", "admin" });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "ID", "Address", "City", "Name", "State", "Zip" },
                values: new object[] { "1", "123 Beer Lane", "Helena", "Brewery", "MT", "12345" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "FName", "LName", "Password", "Type" },
                values: new object[] { "1", "manager1@email.net", "John", "Smith", "password", "manager" });

            migrationBuilder.InsertData(
                table: "ManagersJoint",
                columns: new[] { "ID", "BreweryID", "UserID" },
                values: new object[] { "1", "1", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_BeerItems_BeerID",
                table: "BeerItems",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_BeerItems_BreweryID",
                table: "BeerItems",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_BeerID",
                table: "LineItems",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrderID",
                table: "LineItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagersJoint_BreweryID",
                table: "ManagersJoint",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagersJoint_UserID",
                table: "ManagersJoint",
                column: "UserID");

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
                name: "BeerItems");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "ManagersJoint");

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

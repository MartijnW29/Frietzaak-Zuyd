using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class OrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gebruikersnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuisnummerToevoeging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emailadres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductBeschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrijs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<int>(type: "int", nullable: false),
                    OrderLineID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Gebruikers_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GebruikerID1 = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID1 = table.Column<int>(type: "int", nullable: true),
                    PoductAmount = table.Column<int>(type: "int", nullable: true),
                    Productprijs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineID);
                    table.ForeignKey(
                        name: "FK_OrderLines_Gebruikers_GebruikerID1",
                        column: x => x.GebruikerID1,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerID");
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderID1",
                        column: x => x.OrderID1,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "GebruikerID", "Emailadres", "Gebruikersnaam", "Huisnummer", "HuisnummerToevoeging", "Plaats", "Straat", "Telefoonnummer" },
                values: new object[] { 1, "henk@gmail.com", "henk", "69", "b", "Heerlen", "HuisWeg", "0669476936" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductBeschrijving", "ProductNaam", "ProductPrijs" },
                values: new object[] { 1, null, "Frikandel", 2.25 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_GebruikerID1",
                table: "OrderLines",
                column: "GebruikerID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderID1",
                table: "OrderLines",
                column: "OrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GebruikerID",
                table: "Orders",
                column: "GebruikerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}

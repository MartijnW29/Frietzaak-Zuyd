using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MoreItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderLineIDs",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderIDs",
                table: "Gebruikers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "OrderlineID", "ProductBeschrijving", "ProductNaam", "ProductPrijs" },
                values: new object[,]
                {
                    { 2, null, null, "Kleine friet", 2.0 },
                    { 3, null, null, "Medium friet", 3.5 },
                    { 4, null, null, "Grote friet", 4.25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "OrderLineIDs",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderIDs",
                table: "Gebruikers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Gebruikers",
                keyColumn: "GebruikerID",
                keyValue: 1,
                column: "OrderIDs",
                value: null);
        }
    }
}

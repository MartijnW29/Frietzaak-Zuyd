using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Gebruikers_GebruikerID1",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "OrderLineID",
                table: "Orders",
                newName: "OrderLineIDs");

            migrationBuilder.RenameColumn(
                name: "GebruikerID1",
                table: "OrderLines",
                newName: "ProductID1");

            migrationBuilder.RenameColumn(
                name: "GebruikerID",
                table: "OrderLines",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_GebruikerID1",
                table: "OrderLines",
                newName: "IX_OrderLines_ProductID1");

            migrationBuilder.AddColumn<string>(
                name: "OrderlineID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "OrderlineID",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductID1",
                table: "OrderLines",
                column: "ProductID1",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductID1",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "OrderlineID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderIDs",
                table: "Gebruikers");

            migrationBuilder.RenameColumn(
                name: "OrderLineIDs",
                table: "Orders",
                newName: "OrderLineID");

            migrationBuilder.RenameColumn(
                name: "ProductID1",
                table: "OrderLines",
                newName: "GebruikerID1");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderLines",
                newName: "GebruikerID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_ProductID1",
                table: "OrderLines",
                newName: "IX_OrderLines_GebruikerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Gebruikers_GebruikerID1",
                table: "OrderLines",
                column: "GebruikerID1",
                principalTable: "Gebruikers",
                principalColumn: "GebruikerID");
        }
    }
}

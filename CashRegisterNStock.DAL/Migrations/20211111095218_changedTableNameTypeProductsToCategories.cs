using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegisterNStock.DAL.Migrations
{
    public partial class changedTableNameTypeProductsToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts");

            migrationBuilder.RenameTable(
                name: "TypeProducts",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "TypeProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegisterNStock.DAL.Migrations
{
    public partial class OrderAndOrderLinePlusChangeNameOfSeveralProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_TypeProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypeProductId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "ImageURL");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeProductId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderLine_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ProductId",
                table: "OrderLine",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeProducts_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "TypeProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_TypeProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeProducts_TypeProductId",
                table: "Products",
                column: "TypeProductId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

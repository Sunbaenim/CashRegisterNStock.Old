using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegisterNStock.DAL.Migrations
{
    public partial class deletingOrderLineNowInCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 195, 18, 7, 130, 82, 113, 144, 133, 20, 81, 45, 138, 184, 74, 204, 160, 139, 147, 28, 231, 23, 84, 187, 7, 11, 111, 25, 172, 109, 63, 34, 188, 177, 135, 160, 9, 120, 87, 40, 56, 236, 144, 152, 129, 153, 37, 230, 182, 213, 83, 8, 69, 126, 251, 179, 66, 65, 167, 251, 35, 129, 151, 120, 170 }, new Guid("a0518924-719e-4772-950d-d1c12aba4497") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 76, 28, 179, 158, 48, 26, 181, 50, 254, 12, 78, 204, 39, 76, 87, 217, 252, 89, 56, 243, 122, 22, 77, 124, 231, 27, 172, 90, 3, 29, 227, 248, 18, 25, 69, 241, 80, 231, 237, 9, 125, 181, 58, 21, 215, 42, 156, 18, 70, 232, 177, 142, 213, 108, 93, 197, 243, 167, 60, 29, 14, 255, 97, 175 }, new Guid("62fc219f-70b5-4d4e-95a5-b0bd2aa9e905") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegisterNStock.DAL.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Salt", "Username" },
                values: new object[] { 1, new byte[] { 76, 28, 179, 158, 48, 26, 181, 50, 254, 12, 78, 204, 39, 76, 87, 217, 252, 89, 56, 243, 122, 22, 77, 124, 231, 27, 172, 90, 3, 29, 227, 248, 18, 25, 69, 241, 80, 231, 237, 9, 125, 181, 58, 21, 215, 42, 156, 18, 70, 232, 177, 142, 213, 108, 93, 197, 243, 167, 60, 29, 14, 255, 97, 175 }, new Guid("62fc219f-70b5-4d4e-95a5-b0bd2aa9e905"), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

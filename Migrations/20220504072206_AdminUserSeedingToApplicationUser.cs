using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examCreator.Migrations
{
    public partial class AdminUserSeedingToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "UserId", "LoggedInSecret", "Password", "UserName" },
                values: new object[] { new Guid("ea5ae113-c88e-4b4b-a7b2-dae9d34840aa"), null, "Temp1234*", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "UserId",
                keyValue: new Guid("ea5ae113-c88e-4b4b-a7b2-dae9d34840aa"));
        }
    }
}

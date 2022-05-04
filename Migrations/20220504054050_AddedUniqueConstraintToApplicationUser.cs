using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examCreator.Migrations
{
    public partial class AddedUniqueConstraintToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_UserName",
                table: "ApplicationUser",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_UserName",
                table: "ApplicationUser");
        }
    }
}

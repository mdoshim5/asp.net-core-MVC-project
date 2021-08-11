using Microsoft.EntityFrameworkCore.Migrations;

namespace PaintingStore.Migrations
{
    public partial class membershipadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Membership",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Membership",
                table: "AspNetUsers");
        }
    }
}

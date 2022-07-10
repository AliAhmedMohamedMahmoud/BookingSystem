using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "HotelBranches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HotelBranches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

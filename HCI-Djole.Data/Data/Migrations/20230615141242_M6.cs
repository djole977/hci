using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCI_Djole.Data.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Flights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Review",
                table: "Flights",
                type: "int",
                nullable: true);
        }
    }
}

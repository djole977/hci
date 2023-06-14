using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCI_Djole.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportFromId",
                table: "FlightRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirportToId",
                table: "FlightRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoutes_AirportFromId",
                table: "FlightRoutes",
                column: "AirportFromId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoutes_AirportToId",
                table: "FlightRoutes",
                column: "AirportToId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightRoutes_Airports_AirportFromId",
                table: "FlightRoutes",
                column: "AirportFromId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightRoutes_Airports_AirportToId",
                table: "FlightRoutes",
                column: "AirportToId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightRoutes_Airports_AirportFromId",
                table: "FlightRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightRoutes_Airports_AirportToId",
                table: "FlightRoutes");

            migrationBuilder.DropIndex(
                name: "IX_FlightRoutes_AirportFromId",
                table: "FlightRoutes");

            migrationBuilder.DropIndex(
                name: "IX_FlightRoutes_AirportToId",
                table: "FlightRoutes");

            migrationBuilder.DropColumn(
                name: "AirportFromId",
                table: "FlightRoutes");

            migrationBuilder.DropColumn(
                name: "AirportToId",
                table: "FlightRoutes");
        }
    }
}

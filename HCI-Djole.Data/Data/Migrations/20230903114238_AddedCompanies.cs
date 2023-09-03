using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCI_Djole.Data.Migrations
{
    public partial class AddedCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightCompany_FlightCompanyId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightCompany",
                table: "FlightCompany");

            migrationBuilder.RenameTable(
                name: "FlightCompany",
                newName: "FlightCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightCompanies",
                table: "FlightCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightCompanies_FlightCompanyId",
                table: "Flights",
                column: "FlightCompanyId",
                principalTable: "FlightCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightCompanies_FlightCompanyId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightCompanies",
                table: "FlightCompanies");

            migrationBuilder.RenameTable(
                name: "FlightCompanies",
                newName: "FlightCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightCompany",
                table: "FlightCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightCompany_FlightCompanyId",
                table: "Flights",
                column: "FlightCompanyId",
                principalTable: "FlightCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

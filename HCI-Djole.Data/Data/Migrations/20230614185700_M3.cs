using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCI_Djole.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightCompanyId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlightCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCompany", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightCompanyId",
                table: "Flights",
                column: "FlightCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightCompany_FlightCompanyId",
                table: "Flights",
                column: "FlightCompanyId",
                principalTable: "FlightCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightCompany_FlightCompanyId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "FlightCompany");

            migrationBuilder.DropIndex(
                name: "IX_Flights_FlightCompanyId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightCompanyId",
                table: "Flights");
        }
    }
}

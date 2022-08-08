using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class LastHourTableScript4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionSolarGeneratedWh",
                table: "RawData",
                newName: "SolarGeneratedWh");

            migrationBuilder.RenameColumn(
                name: "SessionConsumptionWh",
                table: "RawData",
                newName: "ConsumptionWh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SolarGeneratedWh",
                table: "RawData",
                newName: "SessionSolarGeneratedWh");

            migrationBuilder.RenameColumn(
                name: "ConsumptionWh",
                table: "RawData",
                newName: "SessionConsumptionWh");
        }
    }
}

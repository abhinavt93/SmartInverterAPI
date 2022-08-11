using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class UserConfigTableCreateAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDataAndConfig",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumBatteryPerc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatteryCapacitykWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SolarPanelCapacityWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NextGridCutOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataAndConfig", x => x.CustomerID);
                });

            migrationBuilder.InsertData(
                table: "UserDataAndConfig",
                columns: new[] { "CustomerID", "BatteryCapacitykWh", "LoggedAt", "MinimumBatteryPerc", "NextGridCutOffTime", "SolarPanelCapacityWatts" },
                values: new object[] { 610, 1.8m, new DateTime(2022, 8, 11, 19, 45, 19, 711, DateTimeKind.Local).AddTicks(930), 10m, new DateTime(2022, 8, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), 330m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDataAndConfig");
        }
    }
}

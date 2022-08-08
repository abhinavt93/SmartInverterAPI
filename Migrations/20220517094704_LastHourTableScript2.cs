using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class LastHourTableScript2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastHourData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleCount = table.Column<int>(type: "int", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    AvgSolarOutputWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SolarGeneratedWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvgLoadWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumptionWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatteryPerc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeIntervalSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastHourData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastHourData");
        }
    }
}

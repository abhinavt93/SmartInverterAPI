using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class InitialScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolarOutputWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SessionSolarGeneratedKWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoadWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SessionConsumptionKWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatteryPerc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerSource = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeIntervalSec = table.Column<int>(type: "int", nullable: false),
                    StrName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawData", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawData");
        }
    }
}

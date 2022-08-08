using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class RemoveTimeIntervalColumnScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeIntervalSec",
                table: "LastYearData");

            migrationBuilder.DropColumn(
                name: "TimeIntervalSec",
                table: "LastHourData");

            migrationBuilder.DropColumn(
                name: "TimeIntervalSec",
                table: "LastDecadeData");

            migrationBuilder.DropColumn(
                name: "TimeIntervalSec",
                table: "LastDayData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalSec",
                table: "LastYearData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalSec",
                table: "LastHourData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalSec",
                table: "LastDecadeData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalSec",
                table: "LastDayData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

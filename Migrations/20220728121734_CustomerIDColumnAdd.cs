using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class CustomerIDColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "RawData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "LastYearData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "LastMonthData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "LastHourData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "LastDecadeData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "LastDayData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "RawData");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "LastYearData");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "LastMonthData");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "LastHourData");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "LastDecadeData");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "LastDayData");
        }
    }
}

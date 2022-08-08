using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class LastHourTableScript3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "LastHourData",
                newName: "Minute");

            migrationBuilder.InsertData(
                table: "LastHourData",
                columns: new[] { "Id", "AvgLoadWatts", "AvgSolarOutputWatts", "BatteryPerc", "ConsumptionWh", "Day", "LoggedAt", "Minute", "PowerSource", "SampleCount", "SolarGeneratedWh", "TimeIntervalSec" },
                values: new object[,]
                {
                    { 1, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 0m, 0 },
                    { 2, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, 0m, 0 },
                    { 3, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 0, 0m, 0 },
                    { 4, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 0, 0m, 0 },
                    { 5, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 0, 0m, 0 },
                    { 6, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 0, 0m, 0 },
                    { 7, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 0, 0m, 0 },
                    { 8, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 0, 0m, 0 },
                    { 9, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, 0, 0m, 0 },
                    { 10, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, 0m, 0 },
                    { 11, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, 0, 0m, 0 },
                    { 12, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, null, 0, 0m, 0 },
                    { 13, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null, 0, 0m, 0 },
                    { 14, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, null, 0, 0m, 0 },
                    { 15, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, 0, 0m, 0 },
                    { 16, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, null, 0, 0m, 0 },
                    { 17, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, null, 0, 0m, 0 },
                    { 18, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, null, 0, 0m, 0 },
                    { 19, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, null, 0, 0m, 0 },
                    { 20, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null, 0, 0m, 0 },
                    { 21, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, null, 0, 0m, 0 },
                    { 22, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, null, 0, 0m, 0 },
                    { 23, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, null, 0, 0m, 0 },
                    { 24, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, null, 0, 0m, 0 },
                    { 25, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, null, 0, 0m, 0 },
                    { 26, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, null, 0, 0m, 0 },
                    { 27, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, null, 0, 0m, 0 },
                    { 28, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, null, 0, 0m, 0 },
                    { 29, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, null, 0, 0m, 0 },
                    { 30, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, null, 0, 0m, 0 },
                    { 31, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, null, 0, 0m, 0 },
                    { 32, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, null, 0, 0m, 0 },
                    { 33, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, null, 0, 0m, 0 },
                    { 34, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, null, 0, 0m, 0 },
                    { 35, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, null, 0, 0m, 0 },
                    { 36, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, null, 0, 0m, 0 },
                    { 37, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, null, 0, 0m, 0 },
                    { 38, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, null, 0, 0m, 0 },
                    { 39, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, null, 0, 0m, 0 },
                    { 40, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, null, 0, 0m, 0 },
                    { 41, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, null, 0, 0m, 0 },
                    { 42, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, null, 0, 0m, 0 }
                });

            migrationBuilder.InsertData(
                table: "LastHourData",
                columns: new[] { "Id", "AvgLoadWatts", "AvgSolarOutputWatts", "BatteryPerc", "ConsumptionWh", "Day", "LoggedAt", "Minute", "PowerSource", "SampleCount", "SolarGeneratedWh", "TimeIntervalSec" },
                values: new object[,]
                {
                    { 43, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, null, 0, 0m, 0 },
                    { 44, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, null, 0, 0m, 0 },
                    { 45, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, null, 0, 0m, 0 },
                    { 46, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, null, 0, 0m, 0 },
                    { 47, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, null, 0, 0m, 0 },
                    { 48, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, null, 0, 0m, 0 },
                    { 49, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, null, 0, 0m, 0 },
                    { 50, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, null, 0, 0m, 0 },
                    { 51, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, null, 0, 0m, 0 },
                    { 52, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, null, 0, 0m, 0 },
                    { 53, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, null, 0, 0m, 0 },
                    { 54, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, null, 0, 0m, 0 },
                    { 55, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, null, 0, 0m, 0 },
                    { 56, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, null, 0, 0m, 0 },
                    { 57, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, null, 0, 0m, 0 },
                    { 58, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, null, 0, 0m, 0 },
                    { 59, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, null, 0, 0m, 0 },
                    { 60, 0m, 0m, 0m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, null, 0, 0m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "LastHourData",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.RenameColumn(
                name: "Minute",
                table: "LastHourData",
                newName: "Hour");
        }
    }
}

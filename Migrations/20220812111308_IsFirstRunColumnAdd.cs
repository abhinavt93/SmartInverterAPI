using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class IsFirstRunColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsFirstRun",
                table: "UserDataAndConfig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserDataAndConfig",
                keyColumn: "CustomerID",
                keyValue: 610,
                columns: new[] { "IsFirstRun", "LoggedAt", "NextGridCutOffTime" },
                values: new object[] { "Y", new DateTime(2022, 8, 12, 12, 13, 7, 600, DateTimeKind.Local).AddTicks(9900), new DateTime(2022, 8, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstRun",
                table: "UserDataAndConfig");

            migrationBuilder.UpdateData(
                table: "UserDataAndConfig",
                keyColumn: "CustomerID",
                keyValue: 610,
                columns: new[] { "LoggedAt", "NextGridCutOffTime" },
                values: new object[] { new DateTime(2022, 8, 11, 19, 45, 19, 711, DateTimeKind.Local).AddTicks(930), new DateTime(2022, 8, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class IsNextGridTimeUpdatedColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsNextGridCutOffTimeUpdated",
                table: "UserDataAndConfig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserDataAndConfig",
                keyColumn: "CustomerID",
                keyValue: 610,
                columns: new[] { "IsNextGridCutOffTimeUpdated", "LoggedAt", "NextGridCutOffTime" },
                values: new object[] { "N", new DateTime(2022, 8, 12, 16, 7, 1, 417, DateTimeKind.Local).AddTicks(4720), new DateTime(2022, 8, 13, 6, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNextGridCutOffTimeUpdated",
                table: "UserDataAndConfig");

            migrationBuilder.UpdateData(
                table: "UserDataAndConfig",
                keyColumn: "CustomerID",
                keyValue: 610,
                columns: new[] { "LoggedAt", "NextGridCutOffTime" },
                values: new object[] { new DateTime(2022, 8, 12, 12, 13, 7, 600, DateTimeKind.Local).AddTicks(9900), new DateTime(2022, 8, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

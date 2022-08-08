using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class LastHourTableScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrName",
                table: "RawData");

            migrationBuilder.RenameColumn(
                name: "SessionSolarGeneratedKWh",
                table: "RawData",
                newName: "SessionSolarGeneratedWh");

            migrationBuilder.RenameColumn(
                name: "SessionConsumptionKWh",
                table: "RawData",
                newName: "SessionConsumptionWh");

            migrationBuilder.AlterColumn<string>(
                name: "PowerSource",
                table: "RawData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionSolarGeneratedWh",
                table: "RawData",
                newName: "SessionSolarGeneratedKWh");

            migrationBuilder.RenameColumn(
                name: "SessionConsumptionWh",
                table: "RawData",
                newName: "SessionConsumptionKWh");

            migrationBuilder.AlterColumn<decimal>(
                name: "PowerSource",
                table: "RawData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrName",
                table: "RawData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

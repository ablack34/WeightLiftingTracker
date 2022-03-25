using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerAPI.Migrations
{
    public partial class SeedDataDateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "LiftingStats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LiftingStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}

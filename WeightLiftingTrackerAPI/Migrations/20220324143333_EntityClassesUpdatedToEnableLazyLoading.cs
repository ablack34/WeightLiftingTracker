using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerAPI.Migrations
{
    public partial class EntityClassesUpdatedToEnableLazyLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 24, 14, 33, 33, 648, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 3, 24, 14, 33, 33, 648, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 3, 24, 14, 33, 33, 648, DateTimeKind.Local).AddTicks(7137));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4618));
        }
    }
}

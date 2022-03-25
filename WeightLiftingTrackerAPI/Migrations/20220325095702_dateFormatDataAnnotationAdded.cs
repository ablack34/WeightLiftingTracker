using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerAPI.Migrations
{
    public partial class dateFormatDataAnnotationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "LiftingStats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 1,
                column: "Date",
                value: "25/03/2022 00:00:00");

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 2,
                column: "Date",
                value: "25/03/2022 00:00:00");

            migrationBuilder.UpdateData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 3,
                column: "Date",
                value: "25/03/2022 00:00:00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "LiftingStats");
        }
    }
}

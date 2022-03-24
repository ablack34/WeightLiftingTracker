using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerAPI.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Name" },
                values: new object[] { 1, "Squat" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Name" },
                values: new object[] { 2, "Bench" });

            migrationBuilder.InsertData(
                table: "LiftingStats",
                columns: new[] { "LiftingStatId", "Date", "ExerciseId", "Repetitions", "Weight" },
                values: new object[] { 1, new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4546), 1, 5, 100.0 });

            migrationBuilder.InsertData(
                table: "LiftingStats",
                columns: new[] { "LiftingStatId", "Date", "ExerciseId", "Repetitions", "Weight" },
                values: new object[] { 2, new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4614), 1, 5, 105.0 });

            migrationBuilder.InsertData(
                table: "LiftingStats",
                columns: new[] { "LiftingStatId", "Date", "ExerciseId", "Repetitions", "Weight" },
                values: new object[] { 3, new DateTime(2022, 3, 24, 13, 28, 54, 21, DateTimeKind.Local).AddTicks(4618), 2, 5, 85.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LiftingStats",
                keyColumn: "LiftingStatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 2);
        }
    }
}

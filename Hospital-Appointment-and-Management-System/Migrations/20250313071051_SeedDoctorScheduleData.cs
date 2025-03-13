using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Appointment_and_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorScheduleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotID);
                    table.ForeignKey(
                        name: "FK_TimeSlots_DoctorSchedules_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorSchedules",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                column: "DoctorID",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotID", "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 3, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 5, new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 6, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 8, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 9, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DoctorID",
                table: "TimeSlots",
                column: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");
        }
    }
}

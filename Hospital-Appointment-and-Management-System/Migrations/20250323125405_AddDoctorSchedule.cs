using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_Appointment_and_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "DoctorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "DoctorID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "DoctorID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "DoctorID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "DoctorID",
                keyValue: 10);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "TimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 1,
                columns: new[] { "Date", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 10, 30, 0, 0), true, new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 2,
                columns: new[] { "Date", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 11, 30, 0, 0), true, new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 3,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 12, 30, 0, 0), true, new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 4,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 30, 0, 0), true, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 5,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 10, 30, 0, 0), true, new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 6,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 11, 30, 0, 0), true, new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 7,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 12, 30, 0, 0), true, new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 8,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 30, 0, 0), true, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 9,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 10, 30, 0, 0), true, new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 10,
                columns: new[] { "Date", "DoctorID", "EndTime", "IsAvailable", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 11, 30, 0, 0), true, new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotID", "Date", "DoctorID", "EndTime", "IsAvailable", "IsBooked", "PatientID", "StartTime" },
                values: new object[,]
                {
                    { 11, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 12, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 13, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 14, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 15, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 16, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 17, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 18, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 19, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 20, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 21, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 22, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 23, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 24, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 25, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 26, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 27, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 28, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 29, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 30, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 31, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 32, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 33, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 34, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 35, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 36, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 37, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 38, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 39, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 40, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 41, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 42, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 43, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 44, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 45, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 46, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 47, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 48, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 49, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 50, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 51, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 52, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 53, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 54, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 55, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 56, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 57, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 58, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 59, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 60, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 61, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 62, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 63, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 64, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 65, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 66, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 67, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 68, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 69, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 70, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 71, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 72, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 73, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 74, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 75, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 76, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 77, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 78, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 79, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 80, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 81, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 82, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 83, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 84, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 85, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 86, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 87, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 88, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 89, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 90, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 91, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 92, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 93, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 94, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 95, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 96, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) },
                    { 97, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 10, 30, 0, 0), true, false, null, new TimeSpan(0, 10, 0, 0, 0) },
                    { 98, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 11, 30, 0, 0), true, false, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { 99, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 12, 30, 0, 0), true, false, null, new TimeSpan(0, 12, 0, 0, 0) },
                    { 100, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, new TimeSpan(0, 9, 30, 0, 0), true, false, null, new TimeSpan(0, 9, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "TimeSlots");

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                column: "DoctorID",
                values: new object[]
                {
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 1,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 2,
                columns: new[] { "Date", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 3,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 4,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 5,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 6,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 7,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 8,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 9,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 10,
                columns: new[] { "Date", "DoctorID", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableTimeSlots",
                table: "DoctorSchedules");

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    TimeSlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoctorScheduleDoctorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.TimeSlotID);
                    table.ForeignKey(
                        name: "FK_TimeSlot_DoctorSchedules_DoctorScheduleDoctorID",
                        column: x => x.DoctorScheduleDoctorID,
                        principalTable: "DoctorSchedules",
                        principalColumn: "DoctorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_DoctorScheduleDoctorID",
                table: "TimeSlot",
                column: "DoctorScheduleDoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.AddColumn<string>(
                name: "AvailableTimeSlots",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

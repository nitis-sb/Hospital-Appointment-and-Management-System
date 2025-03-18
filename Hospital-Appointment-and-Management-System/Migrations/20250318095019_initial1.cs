using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorScheduleDoctorID",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_DoctorScheduleDoctorID",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleDoctorID",
                table: "TimeSlots");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DoctorID",
                table: "TimeSlots",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorID",
                table: "TimeSlots",
                column: "DoctorID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorID",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_DoctorID",
                table: "TimeSlots");

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleDoctorID",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 1,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 2,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 3,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 4,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 5,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 6,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 7,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 8,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 9,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "TimeSlotID",
                keyValue: 10,
                column: "DoctorScheduleDoctorID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DoctorScheduleDoctorID",
                table: "TimeSlots",
                column: "DoctorScheduleDoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorScheduleDoctorID",
                table: "TimeSlots",
                column: "DoctorScheduleDoctorID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorID");
        }
    }
}

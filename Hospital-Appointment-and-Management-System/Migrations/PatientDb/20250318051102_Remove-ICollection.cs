using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations.PatientDb
{
    /// <inheritdoc />
    public partial class RemoveICollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DoctorSchedules_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PatientProfiles_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_PatientProfiles_PatientProfilePatientID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_PatientProfilePatientID",
                table: "Notifications");

           

            
            migrationBuilder.DropColumn(
                name: "PatientProfilePatientID",
                table: "Notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientProfilePatientID",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PatientProfilePatientID",
                table: "Notifications",
                column: "PatientProfilePatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DoctorSchedules_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PatientProfiles_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_PatientProfiles_PatientProfilePatientID",
                table: "Notifications",
                column: "PatientProfilePatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID");
        }
    }
}

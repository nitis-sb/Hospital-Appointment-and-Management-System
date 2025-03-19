using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations.PatientDb
{
    /// <inheritdoc />
    public partial class AddUserIdPatientProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientProfilePatientID",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_PatientProfilePatientID",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "PatientProfilePatientID",
                table: "MedicalHistories");

         

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PatientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "MedicalHistories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientID",
                table: "MedicalHistories",
                column: "PatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientID",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_PatientID",
                table: "MedicalHistories");


            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PatientProfiles");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfVisit",
                table: "MedicalHistories",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "PatientProfilePatientID",
                table: "MedicalHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientProfilePatientID",
                table: "MedicalHistories",
                column: "PatientProfilePatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientProfilePatientID",
                table: "MedicalHistories",
                column: "PatientProfilePatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations.PatientDb
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlot_DoctorSchedules_DoctorID",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot");

            migrationBuilder.RenameTable(
                name: "TimeSlot",
                newName: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "TimeSlots",
                newName: "DoctorScheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlot_DoctorID",
                table: "TimeSlots",
                newName: "IX_TimeSlots_DoctorScheduleID");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleID",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules",
                column: "DoctorScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots",
                column: "TimeSlotID");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorID",
                table: "DoctorSchedules",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotID",
                table: "Appointments",
                column: "TimeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DoctorSchedules_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorScheduleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PatientProfiles_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TimeSlots_TimeSlotID",
                table: "Appointments",
                column: "TimeSlotID",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorID",
                table: "DoctorSchedules",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorScheduleID",
                table: "TimeSlots",
                column: "DoctorScheduleID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorScheduleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DoctorSchedules_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PatientProfiles_PatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TimeSlots_TimeSlotID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorID",
                table: "DoctorSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_DoctorSchedules_DoctorScheduleID",
                table: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_DoctorID",
                table: "DoctorSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TimeSlotID",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleID",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "TimeSlotID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "TimeSlots");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                newName: "TimeSlot");

            migrationBuilder.RenameColumn(
                name: "DoctorScheduleID",
                table: "TimeSlot",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlots_DoctorScheduleID",
                table: "TimeSlot",
                newName: "IX_TimeSlot_DoctorID");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules",
                column: "DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot",
                column: "TimeSlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_DoctorSchedules_DoctorID",
                table: "TimeSlot",
                column: "DoctorID",
                principalTable: "DoctorSchedules",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

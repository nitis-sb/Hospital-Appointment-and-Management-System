﻿// <auto-generated />
using System;
using Hospital_Appointment_and_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_Appointment_and_Management_System.Migrations.PatientDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250318051321_MinorChange1-DoctorIDAppointment")]
    partial class MinorChange1DoctorIDAppointment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int")
                        .HasColumnName("DoctorID");

                    b.Property<int>("PatientID")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.DoctorSchedule", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.HasKey("DoctorID");

                    b.ToTable("DoctorSchedules");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.MedicalHistory", b =>
                {
                    b.Property<int>("HistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryID"));

                    b.Property<DateOnly>("DateOfVisit")
                        .HasColumnType("date");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientProfilePatientID")
                        .HasColumnType("int");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("HistoryID");

                    b.HasIndex("PatientProfilePatientID");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationID"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("NotificationID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.PatientProfile", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("PatientProfiles");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.TimeSlot", b =>
                {
                    b.Property<int>("TimeSlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSlotID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("TimeSlotID");

                    b.HasIndex("DoctorID");

                    b.ToTable("TimeSlot");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.MedicalHistory", b =>
                {
                    b.HasOne("Hospital_Appointment_and_Management_System.Models.PatientProfile", null)
                        .WithMany("MedicalHistories")
                        .HasForeignKey("PatientProfilePatientID");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.TimeSlot", b =>
                {
                    b.HasOne("Hospital_Appointment_and_Management_System.Models.DoctorSchedule", "DoctorSchedule")
                        .WithMany("AvailableTimeSlots")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorSchedule");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.DoctorSchedule", b =>
                {
                    b.Navigation("AvailableTimeSlots");
                });

            modelBuilder.Entity("Hospital_Appointment_and_Management_System.Models.PatientProfile", b =>
                {
                    b.Navigation("MedicalHistories");
                });
#pragma warning restore 612, 618
        }
    }
}

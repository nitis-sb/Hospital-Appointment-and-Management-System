using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.DoctorSchedule)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.PatientProfile)
                .WithMany()
                .HasForeignKey(a => a.PatientID);
            
            modelBuilder.Entity<Appointment>().HasData(
               new Appointment
               {
                   AppointmentID = 1,
                   PatientID = 1,
                   DoctorId = 2,
                   AppointmentDate = DateTime.Now,
                   Status = "Scheduled"
               },
               new Appointment
               {
                   AppointmentID = 2,
                   PatientID = 2,
                   DoctorId = 1,
                   AppointmentDate = DateTime.Now,
                   Status = "Scheduled"
               }
           );
            */

        // Seed initial data
        /*
        modelBuilder.Entity<DoctorSchedule>().HasData(
            new DoctorSchedule { DoctorID = 201, AvailableTimeSlots = "09:00-12:00" },
            new DoctorSchedule { DoctorID = 202, AvailableTimeSlots = "13:00-16:00" }
        );
        modelBuilder.Entity<PatientProfile>().HasData(
            new PatientProfile { PatientID = 101, Name = "BrettLee", DateOfBirth = new DateOnly(1980, 1, 1), ContactDetails = "brettlee@example.com" },
            new PatientProfile { PatientID = 102, Name = "BruceLee", DateOfBirth = new DateOnly(1990, 2, 2), ContactDetails = "brucelee@example.com" }
        );



        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                AppointmentID = 1,
                PatientID = 101,
                DoctorId = 201,
                AppointmentDate = DateTime.Now,
                Status = "Scheduled"
            },
            new Appointment
            {
                AppointmentID = 2,
                PatientID = 102,
                DoctorId = 202,
                AppointmentDate = DateTime.Now,
                Status = "Scheduled"
            }
        );
        */
    }
}

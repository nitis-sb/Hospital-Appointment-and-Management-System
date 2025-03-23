using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class DoctorScheduleDbContext : DbContext
    {
        public DoctorScheduleDbContext(DbContextOptions<DoctorScheduleDbContext> options) : base(options) { }

        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for 5 doctors
            var doctorSchedules = new List<DoctorSchedule>
            {
                new DoctorSchedule { DoctorID = 1 },
                new DoctorSchedule { DoctorID = 2 },
                new DoctorSchedule { DoctorID = 3 },
                new DoctorSchedule { DoctorID = 4 },
                new DoctorSchedule { DoctorID = 5 }
            };

            modelBuilder.Entity<DoctorSchedule>().HasData(doctorSchedules);

            // Seed data for 5 time slots for each doctor
            var timeSlots = new List<TimeSlot>();
            for (int doctorId = 1; doctorId <= 5; doctorId++)
            {
                for (int i = 1; i <= 5; i++)
                {
                    timeSlots.Add(new TimeSlot
                    {
                        TimeSlotID = (doctorId - 1) * 5 + i,
                        Date = DateTime.Today.AddDays(i % 7), // Spread time slots over a week
                        StartTime = new TimeSpan(9 + (i % 4), 0, 0), // 4 slots per hour starting from 9 AM
                        EndTime = new TimeSpan(9 + (i % 4), 30, 0),
                        IsAvailable = false,
                        DoctorID = doctorId
                    });
                }
            }

            modelBuilder.Entity<TimeSlot>().HasData(timeSlots);
        }
    }
}
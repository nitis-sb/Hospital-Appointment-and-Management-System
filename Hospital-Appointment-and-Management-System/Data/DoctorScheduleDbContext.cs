using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class DoctorScheduleDbContext : DbContext
    {
        public DoctorScheduleDbContext(DbContextOptions<DoctorScheduleDbContext> options) : base(options)
        {
        }

        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for DoctorSchedules
            modelBuilder.Entity<DoctorSchedule>().HasData(
                new DoctorSchedule { DoctorID = 1 },
                new DoctorSchedule { DoctorID = 2 },
                new DoctorSchedule { DoctorID = 3 },
                new DoctorSchedule { DoctorID = 4 },
                new DoctorSchedule { DoctorID = 5 },
                new DoctorSchedule { DoctorID = 6 },
                new DoctorSchedule { DoctorID = 7 },
                new DoctorSchedule { DoctorID = 8 },
                new DoctorSchedule { DoctorID = 9 },
                new DoctorSchedule { DoctorID = 10 }
            );

            // Seed data for TimeSlots
            modelBuilder.Entity<TimeSlot>().HasData(
                new TimeSlot { TimeSlotID = 1, Date = new DateTime(2025, 3, 14), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), DoctorID = 1 },
                new TimeSlot { TimeSlotID = 2, Date = new DateTime(2025, 3, 14), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(16, 0, 0), DoctorID = 1 },
                new TimeSlot { TimeSlotID = 3, Date = new DateTime(2025, 3, 15), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0), DoctorID = 2 },
                new TimeSlot { TimeSlotID = 4, Date = new DateTime(2025, 3, 15), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(15, 0, 0), DoctorID = 2 },
                new TimeSlot { TimeSlotID = 5, Date = new DateTime(2025, 3, 16), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), DoctorID = 3 },
                new TimeSlot { TimeSlotID = 6, Date = new DateTime(2025, 3, 17), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(10, 0, 0), DoctorID = 4 },
                new TimeSlot { TimeSlotID = 7, Date = new DateTime(2025, 3, 17), StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(13, 0, 0), DoctorID = 4 },
                new TimeSlot { TimeSlotID = 8, Date = new DateTime(2025, 3, 18), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(16, 0, 0), DoctorID = 5 },
                new TimeSlot { TimeSlotID = 9, Date = new DateTime(2025, 3, 19), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), DoctorID = 6 },
                new TimeSlot { TimeSlotID = 10, Date = new DateTime(2025, 3, 20), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0), DoctorID = 7 }
            );
        }
    }
}
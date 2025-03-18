using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Appointment_and_Management_System.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }
        public DbSet<Notification> Notifications { get; set; }


        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PatientProfile to MedicalHistory (One-to-Many)
            modelBuilder.Entity<MedicalHistory>()
                .HasOne(m => m.PatientProfile)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(m => m.PatientID);

            // PatientProfile to Appointment (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.PatientProfile)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID);

            // DoctorSchedule to Appointment (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.DoctorSchedule)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID);

            // PatientProfile to Notification (One-to-Many)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.PatientProfile)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.PatientID);


        }
        */

    }


}

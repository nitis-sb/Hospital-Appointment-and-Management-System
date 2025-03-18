using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
    }
}

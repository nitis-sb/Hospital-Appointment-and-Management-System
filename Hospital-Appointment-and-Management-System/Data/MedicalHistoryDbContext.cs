using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class MedicalHistoryDbContext : DbContext
    {
        public MedicalHistoryDbContext(DbContextOptions<MedicalHistoryDbContext> options) : base(options)
        {
        }

        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalHistory>()
                .HasOne(pp => pp.PatientProfile)
                .WithMany(mh => mh.MedicalHistories)
                .HasForeignKey(pp => pp.PatientID);

           

            modelBuilder.Entity<MedicalHistory>().HasData(
                new MedicalHistory
                {
                    HistoryID = 1,
                    PatientID = 1,
                    Diagnosis = "Hypertension",
                    Treatment = "Lifestyle modification, medication",
                    DateOfVisit = new DateTime(2023, 3, 10)
                },
                new MedicalHistory
                {
                    HistoryID = 4,
                    PatientID = 1,
                    Diagnosis = "Diarrhea",
                    Treatment = "Dietary changes, medication",
                    DateOfVisit = new DateTime(2024, 1, 10)
                },
                new MedicalHistory
                {
                    HistoryID = 3,
                    PatientID = 2,
                    Diagnosis = "Asthma",
                    Treatment = "Inhaler, allergy management",
                    DateOfVisit = new DateTime(2023, 6, 5)
                }
            );

        }
        */


    }
}

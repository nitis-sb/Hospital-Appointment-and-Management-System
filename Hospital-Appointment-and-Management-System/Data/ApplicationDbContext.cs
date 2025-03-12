using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    }
}

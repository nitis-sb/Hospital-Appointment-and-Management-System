using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DoctorSchedule> GetDoctorScheduleAsync(int doctorId)
        {
            return await _context.DoctorSchedules
                .Include(ds => ds.AvailableTimeSlots)
                .FirstOrDefaultAsync(ds => ds.DoctorID == doctorId);
        }

        public async Task UpdateDoctorScheduleAsync(DoctorSchedule schedule)
        {
            _context.DoctorSchedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
    }
}

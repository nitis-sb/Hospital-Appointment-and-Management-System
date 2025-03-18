using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly DoctorScheduleDbContext _context;

        public DoctorScheduleRepository(DoctorScheduleDbContext context)
        {
            _context = context;
        }

        public List<TimeSlot> GetAvailableTimeSlots(int doctorId)
        {
            return _context.DoctorSchedules
                           .Where(ds => ds.DoctorID == doctorId)
                           .SelectMany(ds => ds.AvailableTimeSlots)
                           .ToList();
        }

        public void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots)
        {
            var doctorSchedule = _context.DoctorSchedules
                                         .Include(ds => ds.AvailableTimeSlots) // Include the related time slots
                                         .FirstOrDefault(ds => ds.DoctorID == doctorId);

            if (doctorSchedule == null)
            {
                throw new Exception("Doctor schedule not found.");
            }

            foreach (var timeSlot in timeSlots)
            {
                var existingTimeSlot = doctorSchedule.AvailableTimeSlots
                                                     .FirstOrDefault(ts => ts.TimeSlotID == timeSlot.TimeSlotID);
                if (existingTimeSlot != null)
                {
                    existingTimeSlot.Date = timeSlot.Date;
                    existingTimeSlot.StartTime = timeSlot.StartTime;
                    existingTimeSlot.EndTime = timeSlot.EndTime;
                    existingTimeSlot.IsBooked = timeSlot.IsBooked; // Update booking status
                    existingTimeSlot.PatientID = timeSlot.PatientID; // Update patient ID
                }
            }
            _context.SaveChanges();
        }
    }
}

//return await _context.DoctorSchedules
//    .Include(ds => ds.AvailableTimeSlots)
//    .FirstAsync(ds => ds.DoctorID == doctorId);
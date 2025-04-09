using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly PatientDbContext _context;

        public DoctorScheduleRepository(PatientDbContext context)
        {
            _context = context;
        }

        public List<TimeSlot> GetDoctorSchedule(int doctorId)
        {
            return _context.DoctorSchedules
                           .Where(ds => ds.DoctorID == doctorId)
                           .SelectMany(ds => ds.AvailableTimeSlots)
                           .ToList();
        }

        public void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots)
        {
            var doctorSchedule = _context.DoctorSchedules
                                         .Include(ds => ds.AvailableTimeSlots)
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
                    existingTimeSlot.IsBooked = timeSlot.IsBooked;
                    existingTimeSlot.PatientID = timeSlot.PatientID;
                    existingTimeSlot.IsAvailable = timeSlot.IsAvailable;
                }
                else
                {
                    doctorSchedule.AvailableTimeSlots.Add(timeSlot);
                }
            }
            _context.SaveChanges();
        }
    }
}
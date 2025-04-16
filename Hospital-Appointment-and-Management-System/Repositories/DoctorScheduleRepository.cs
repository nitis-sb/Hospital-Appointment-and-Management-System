using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
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

        public async Task<List<DoctorScheduleDto>> GetAllDoctorSchedulesAsync()
        {
            var doctorSchedules = await _context.DoctorSchedules
                .Include(ds => ds.AvailableTimeSlots)
                .Include(ds => ds.Doctor) // Include the Doctor entity
                .ToListAsync();

            var groupedSchedules = doctorSchedules
                .GroupBy(ds => ds.DoctorID)
                .Select(g => new DoctorScheduleDto
                {
                    Doctor = new DoctorDto
                    {
                        DoctorId = g.First().Doctor.DoctorID,
                        Name = g.First().Doctor.Name,
                        Email = g.First().Doctor.Email,
                        AvailableTimeSlots = g.SelectMany(ds => ds.AvailableTimeSlots.Select(ts => new TimeSlotDto
                        {
                            TimeSlotID = ts.TimeSlotID,
                            Date = ts.Date,
                            StartTime = ts.StartTime,
                            EndTime = ts.EndTime,
                            IsBooked = ts.IsBooked,
                            PatientID = ts.PatientID,
                            IsAvailable = ts.IsAvailable,
                            CancelReason = ts.CancelReason
                        })).ToList()
                    }
                }).ToList();

            return groupedSchedules;
        }


        public List<TimeSlot> GetDoctorSchedule(int doctorId)
        {
            return _context.DoctorSchedules
                .Where(ds => ds.DoctorID == doctorId)
                .Include(ds => ds.AvailableTimeSlots)
                .SelectMany(ds => ds.AvailableTimeSlots)
                .ToList();
        }

        public void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots)
        {
            var doctorSchedule = _context.DoctorSchedules
                .Include(ds => ds.AvailableTimeSlots)
                .FirstOrDefault(ds => ds.DoctorID == doctorId);

            if (doctorSchedule == null)
                throw new Exception("Doctor schedule not found.");

            foreach (var timeSlot in timeSlots)
            {
                var existingSlot = doctorSchedule.AvailableTimeSlots
                    .FirstOrDefault(ts => ts.TimeSlotID == timeSlot.TimeSlotID);

                if (existingSlot != null)
                {
                    existingSlot.Date = timeSlot.Date;
                    existingSlot.StartTime = timeSlot.StartTime;
                    existingSlot.EndTime = timeSlot.EndTime;
                    existingSlot.IsBooked = timeSlot.IsBooked;
                    existingSlot.PatientID = timeSlot.PatientID;
                    existingSlot.IsAvailable = timeSlot.IsAvailable;
                    existingSlot.CancelReason = timeSlot.CancelReason;
                }
                else
                {
                    timeSlot.DoctorScheduleID = doctorSchedule.DoctorScheduleID;
                    doctorSchedule.AvailableTimeSlots.Add(timeSlot);
                }
            }

            _context.SaveChanges();
        }

        public void AddDoctorSchedule(DoctorSchedule doctorSchedule)
        {
            _context.DoctorSchedules.Add(doctorSchedule);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotId)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(timeSlotId);

            if (timeSlot == null)
                return false;

            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
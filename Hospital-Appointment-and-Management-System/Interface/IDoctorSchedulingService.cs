using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IDoctorSchedulingService
    {
        Task<List<DoctorScheduleDto>> GetAllDoctorSchedulesAsync();
        List<TimeSlotDto> GetScheduleByDoctorId(int doctorId);
        void UpdateDoctorAvailability(int doctorId, List<TimeSlotDto> timeSlots);
        void AddDoctorSchedule(DoctorScheduleDto doctorSchedule);
        Task<bool> DeleteTimeSlotAsync(int timeSlotId);
    }
}
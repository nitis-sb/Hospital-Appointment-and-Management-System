using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IDoctorScheduleRepository
    {
        Task<List<DoctorScheduleDto>> GetAllDoctorSchedulesAsync();
        List<TimeSlot> GetDoctorSchedule(int doctorId);
        void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots);
        void AddDoctorSchedule(DoctorSchedule doctorSchedule);
        Task<bool> DeleteTimeSlotAsync(int timeSlotId);
    }
}

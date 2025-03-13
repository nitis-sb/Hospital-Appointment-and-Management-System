using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public interface IDoctorScheduleRepository
    {
        List<TimeSlot> GetAvailableTimeSlots(int doctorId);
        void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots);
    }
}

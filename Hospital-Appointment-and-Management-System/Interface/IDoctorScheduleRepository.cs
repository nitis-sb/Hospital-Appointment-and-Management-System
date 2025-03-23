using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IDoctorScheduleRepository
    {
        List<TimeSlot> GetDoctorSchedule(int doctorId);
        void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots);
    }
}

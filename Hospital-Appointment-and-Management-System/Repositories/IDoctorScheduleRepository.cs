using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public interface IDoctorScheduleRepository
    {
        Task<DoctorSchedule> GetDoctorScheduleAsync(int doctorId);
        Task UpdateDoctorScheduleAsync(DoctorSchedule schedule);
    }
}

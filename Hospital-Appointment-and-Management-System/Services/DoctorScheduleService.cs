using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Repositories;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class DoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _repository;

        public DoctorScheduleService(IDoctorScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<DoctorSchedule> GetDoctorScheduleAsync(int doctorId)
        {
            return await _repository.GetDoctorScheduleAsync(doctorId);
        }

        public async Task UpdateDoctorScheduleAsync(DoctorSchedule schedule)
        {
            await _repository.UpdateDoctorScheduleAsync(schedule);
        }
    }
}

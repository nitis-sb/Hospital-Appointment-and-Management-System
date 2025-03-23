using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class DoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _repository;

        public DoctorScheduleService(IDoctorScheduleRepository repository)
        {
            _repository = repository;
        }

        public List<TimeSlot> GetDoctorSchedule(int doctorId)
        {
            return _repository.GetDoctorSchedule(doctorId);
        }

        public void UpdateDoctorAvailability(int doctorId, List<TimeSlot> timeSlots)
        {
            _repository.UpdateDoctorAvailability(doctorId, timeSlots);
        }
    }
}

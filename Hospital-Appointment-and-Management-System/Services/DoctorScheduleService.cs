using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class DoctorScheduleService : IDoctorSchedulingService
    {
        private readonly IDoctorScheduleRepository _repository;

        public DoctorScheduleService(IDoctorScheduleRepository repository)

        {

            _repository = repository;

        }



        public async Task<List<DoctorScheduleDto>> GetAllDoctorSchedulesAsync()
        {
            return await _repository.GetAllDoctorSchedulesAsync();
        }


        public List<TimeSlotDto> GetScheduleByDoctorId(int doctorId)

        {

            return _repository.GetDoctorSchedule(doctorId)

                .Select(ts => new TimeSlotDto

                {

                    TimeSlotID = ts.TimeSlotID,

                    Date = ts.Date,

                    StartTime = ts.StartTime,

                    EndTime = ts.EndTime,

                    IsBooked = ts.IsBooked,

                    PatientID = ts.PatientID,

                    IsAvailable = ts.IsAvailable,

                    CancelReason = ts.CancelReason,


                }).ToList();

        }

        public void UpdateDoctorAvailability(int doctorId, List<TimeSlotDto> timeSlots)

        {

            var slots = timeSlots.Select(ts => new TimeSlot

            {

                TimeSlotID = ts.TimeSlotID,

                Date = ts.Date,

                StartTime = ts.StartTime,

                EndTime = ts.EndTime,

                IsBooked = ts.IsBooked,

                PatientID = ts.PatientID,

                IsAvailable = ts.IsAvailable,

                CancelReason = ts.CancelReason,

            }).ToList();

            _repository.UpdateDoctorAvailability(doctorId, slots);

        }

        public void AddDoctorSchedule(DoctorScheduleDto scheduleDto)
        {
            var doctorSchedule = new DoctorSchedule
            {
                DoctorID = scheduleDto.Doctor.DoctorId, // Access DoctorID from DoctorDto
                AvailableTimeSlots = scheduleDto.Doctor.AvailableTimeSlots.Select(ts => new TimeSlot
                {
                    Date = ts.Date,
                    StartTime = ts.StartTime,
                    EndTime = ts.EndTime,
                    IsBooked = ts.IsBooked,
                    PatientID = ts.PatientID,
                    IsAvailable = ts.IsAvailable,
                    CancelReason = ts.CancelReason
                }).ToList()
            };

            _repository.AddDoctorSchedule(doctorSchedule);
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotId)
        {
            return await _repository.DeleteTimeSlotAsync(timeSlotId);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Repository;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class AppointmentService : IServiceAppointment
    {
        private readonly IRepositoryAppointment _repository;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly INotificationService _notificationService;

        public AppointmentService(IRepositoryAppointment repository, IDoctorScheduleRepository doctorScheduleRepository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(int appointmentId)
        {
            var appointment = await _repository.GetAppointmentByIdAsync(appointmentId);
            return new AppointmentDto
            {
                AppointmentID = appointment.AppointmentID,
                PatientID = appointment.PatientID,
                DoctorId = appointment.DoctorID,
                AppointmentDate = appointment.AppointmentDate,
                TimeSlotID = appointment.TimeSlotID
            };
        }

        public async Task<List<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var appointments = await _repository.GetAppointmentsByPatientIdAsync(patientId);
            return appointments.Select(a => new AppointmentDto
            {
                AppointmentID = a.AppointmentID,
                PatientID = a.PatientID,
                DoctorId = a.DoctorID,
                AppointmentDate = a.AppointmentDate,
                TimeSlotID = a.TimeSlotID
            }).ToList();
        }

        public async Task AddAppointmentAsync(AppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                TimeSlotID = dto.TimeSlotID
            };
            await _repository.AddAppointmentAsync(appointment);
            var notificationDto = new NotificationDTO
            {
                // Populate notification details based on the appointment
                PatientID = appointment.PatientID,
                Message = $"Appointment created on {appointment.AppointmentDate}",
                Timestamp = appointment.AppointmentDate
                // Add other necessary fields
            };
            await _notificationService.CreateNotificationAsync(notificationDto);
        }

        public async Task UpdateAppointmentAsync(AppointmentDto dto)
        {
            var appointment = new Appointment
            {
                AppointmentID = dto.AppointmentID,
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                TimeSlotID = dto.TimeSlotID
            };
            await _repository.UpdateAppointmentAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            await _repository.DeleteAppointmentAsync(appointmentId);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface IServiceAppointment
    {
        Task<AppointmentDto> GetAppointmentByIdAsync(int appointmentId);
        Task<List<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId);
        Task AddAppointmentAsync(AppointmentDto dto);
        Task UpdateAppointmentAsync(AppointmentDto dto);
        Task DeleteAppointmentAsync(int appointmentId);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface IRepositoryAppointment
    {
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int appointmentId);
    }
}
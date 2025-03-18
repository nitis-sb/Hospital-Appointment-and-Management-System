using Hospital_Appointment_and_Management_System.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Management_System.Services
{
    public interface IServiceAppointment
    {
        Task<IEnumerable<AppointmentDto>> GetAll();
        Task<AppointmentDto> GetElementById(int id);
        Task<AppointmentDto> Create(AppointmentDto appointmentDto);
        Task<AppointmentDto> Update(AppointmentDto appointmentDto);
        Task<bool> Delete(int id);
    }
}
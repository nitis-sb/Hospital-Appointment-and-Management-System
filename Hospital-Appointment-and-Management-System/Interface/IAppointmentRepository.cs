using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTOs;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface IRepositoryAppointment
    {
        Task<IEnumerable<AppointmentDto>> GetAll();
        Task<AppointmentDto> GetElementById(int id);
        Task<AppointmentDto> Create(AppointmentDto appointmentDto);
        Task<AppointmentDto> Update(AppointmentDto appointmentDto);
        Task<bool> Delete(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Interfaces;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class ServiceAppointment : IServiceAppointment
    {
        private readonly IRepositoryAppointment _repositoryAppointment;

        public ServiceAppointment(IRepositoryAppointment repositoryAppointment)
        {
            _repositoryAppointment = repositoryAppointment;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            return await _repositoryAppointment.GetAll();
        }

        public async Task<AppointmentDto> GetElementById(int id)
        {
            return await _repositoryAppointment.GetElementById(id);
        }

        public async Task<AppointmentDto> Create(AppointmentDto appointmentDto)
        {
            return await _repositoryAppointment.Create(appointmentDto);
        }

        public async Task<AppointmentDto> Update(AppointmentDto appointmentDto)
        {
            return await _repositoryAppointment.Update(appointmentDto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repositoryAppointment.Delete(id);
        }
    }
}
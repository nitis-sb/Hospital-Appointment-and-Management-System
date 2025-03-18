using Hospital_Appointment_and_Management_System.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Data.Service
{
    public class ServiceAppointment : IServiceAppointment
    {
        private readonly AppointmentDbContext _context;

        public ServiceAppointment(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            var appointments = await _context.Appointments.ToListAsync();
            var appointmentDtos = appointments.Select(a => new AppointmentDto
            {
                AppointmentID = a.AppointmentID,
                PatientID = a.PatientID,
                DoctorId = a.DoctorID,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status
            }).ToList();

            return appointmentDtos;
        }

        public async Task<AppointmentDto> GetElementById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID value", nameof(id));
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }

            var appointmentDto = new AppointmentDto
            {
                AppointmentID = appointment.AppointmentID,
                PatientID = appointment.PatientID,
                DoctorId = appointment.DoctorID,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status
            };

            return appointmentDto;
        }

        public async Task<AppointmentDto> Create(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                PatientID = appointmentDto.PatientID,
                DoctorID = appointmentDto.DoctorId,
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            appointmentDto.AppointmentID = appointment.AppointmentID; // Update ID after saving
            return appointmentDto;
        }

        public async Task<AppointmentDto> Update(AppointmentDto appointmentDto)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentDto.AppointmentID);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }

            appointment.PatientID = appointmentDto.PatientID;
            appointment.DoctorID = appointmentDto.DoctorId;
            appointment.AppointmentDate = appointmentDto.AppointmentDate;
            appointment.Status = appointmentDto.Status;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointmentDto;
        }

        public async Task<bool> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
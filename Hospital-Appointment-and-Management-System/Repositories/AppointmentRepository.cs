using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Repository
{
    public class AppointmentRepository : IRepositoryAppointment
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
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
                AppointmentDate = a.AppointmentDate
            }).ToList();

            return appointmentDtos;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _context.Appointments
                .Include(a => a.TimeSlot)
                .FirstOrDefaultAsync(a => a.AppointmentID == appointmentId);
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientID == patientId)
                .ToListAsync();
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(appointment.TimeSlotID);
            if (timeSlot != null && timeSlot.IsAvailable && !timeSlot.IsBooked)
            {
                timeSlot.IsBooked = true;
                timeSlot.PatientID = appointment.PatientID;
                timeSlot.IsAvailable = false;
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                var timeSlot = await _context.TimeSlots.FindAsync(appointment.TimeSlotID);
                if (timeSlot != null)
                {
                    timeSlot.IsBooked = false;
                    timeSlot.PatientID = null;
                    timeSlot.IsAvailable = true;
                }
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
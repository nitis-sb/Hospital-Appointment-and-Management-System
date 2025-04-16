using Hospital_Appointment_and_Management_System.Services;
using Hospital_Appointment_and_Management_System.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hospital_Appointment_and_Management_System.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IServiceAppointment _service;

        public AppointmentController(IServiceAppointment service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAppointmentsByPatientId/{patientId}")]
        public async Task<IActionResult> GetByPatientId(int patientId)
        {
            var appointments = await _service.GetAppointmentsByPatientIdAsync(patientId);
            return Ok(appointments);
        }

        [HttpGet]
        [Route("GetAppointmentById/{appointmentId}")]
        public async Task<IActionResult> GetById(int appointmentId)
        {
            var appointment = await _service.GetAppointmentByIdAsync(appointmentId);
            return Ok(appointment);
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<IActionResult> PostAppointment([FromBody] AppointmentDto dto)
        {
            await _service.AddAppointmentAsync(dto);
            return Ok();
        }

        [Route("UpdateAppointment")]
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentDto dto)
        {
            await _service.UpdateAppointmentAsync(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAppointment/{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            await _service.DeleteAppointmentAsync(appointmentId);
            return Ok();
        }
    }
}
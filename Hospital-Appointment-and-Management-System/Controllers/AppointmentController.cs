using Hospital_Appointment_and_Management_System.Services;
using Hospital_Appointment_and_Management_System.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hospital_Appointment_and_Management_System.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IServiceAppointment _IServiceAppointment;

        public AppointmentController(IServiceAppointment ServiceAppointment)
        {
            _IServiceAppointment = ServiceAppointment;
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var allAppointments = await _IServiceAppointment.GetAll();
            return Ok(allAppointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetElementById(int id)
        {
            var appointment = await _IServiceAppointment.GetElementById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<AppointmentDto>> Create([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest("Invalid appointment data.");
            }

            var createdAppointment = await _IServiceAppointment.Create(appointmentDto);
            return CreatedAtAction(nameof(GetElementById), new { id = createdAppointment.AppointmentID }, createdAppointment);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.AppointmentID)
            {
                return BadRequest();
            }

            await _IServiceAppointment.Update(appointmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _IServiceAppointment.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
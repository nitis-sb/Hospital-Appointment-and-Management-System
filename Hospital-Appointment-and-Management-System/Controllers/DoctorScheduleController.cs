using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly DoctorScheduleService _service;

        public DoctorScheduleController(DoctorScheduleService service)
        {
            _service = service;
        }

        // GET endpoint to show the time slots details of a particular doctor
        [HttpGet("allSchedules")]
        public async Task<IActionResult> GetAllDoctorSchedules()
        {
            var schedules = await _service.GetAllDoctorSchedulesAsync();
            return Ok(schedules);
        }



        [HttpGet("{doctorId}")]
        public IActionResult GetSchedule(int doctorId)
        {
            var schedule = _service.GetScheduleByDoctorId(doctorId);
            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult AddSchedule([FromBody] DoctorScheduleDto doctorSchedule)
        {
            _service.AddDoctorSchedule(doctorSchedule);
            return Ok();
        }

        [HttpPut("{doctorId}")]
        public IActionResult UpdateAvailability(int doctorId, [FromBody] List<TimeSlotDto> timeSlots)
        {
            _service.UpdateDoctorAvailability(doctorId, timeSlots);
            return Ok();
        }

        [HttpDelete("{timeSlotId}")]
        public async Task<IActionResult> DeleteTimeSlot(int timeSlotId)
        {
            var result = await _service.DeleteTimeSlotAsync(timeSlotId);

            if (!result)
                return NotFound("Time slot not found.");

            return Ok("Time slot deleted successfully.");
        }
    }
}
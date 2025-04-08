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
        [HttpGet("{doctorId}/timeslots")]
        [Authorize]
        public ActionResult<DoctorSchedule> GetDoctorSchedule(int doctorId)
        {
            var doctorSchedule = _service.GetDoctorSchedule(doctorId);
            if (doctorSchedule == null)
            {
                return NotFound();
            }
            return Ok(doctorSchedule);
        }

        // PUT endpoint to update available time slots
        [HttpPut("{doctorId}/timeslots")]
        [Authorize]
        public IActionResult UpdateTimeSlots(int doctorId, [FromBody] List<UpdateDoctorAvailabilityDTO> timeSlotsDto)
        {
            var timeSlots = timeSlotsDto.Select(dto => new TimeSlot
            {
                TimeSlotID = dto.TimeSlotID,
                Date = dto.Date, // Parsing string to DateTime
                StartTime = dto.StartTime, // Parsing string to TimeSpan
                EndTime = dto.EndTime, // Parsing string to TimeSpan
                IsBooked = dto.IsBooked,
                PatientID = dto.PatientID,
                IsAvailable = dto.IsAvailable // New property to indicate availability
            }).ToList();

            _service.UpdateDoctorAvailability(doctorId, timeSlots);
            return Ok(new { message = "Doctor availability updated successfully." });
        }
    }
}
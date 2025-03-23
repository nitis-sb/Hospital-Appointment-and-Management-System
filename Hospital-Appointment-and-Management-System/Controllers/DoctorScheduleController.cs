using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{doctorId}")]
        [Authorize]
        public ActionResult<List<TimeSlot>> GetAvailableTimeSlots(int doctorId)
        {
            var timeSlots = _service.GetAvailableTimeSlots(doctorId);
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound();
            }
            return Ok(timeSlots);
        }

        [HttpPut("{doctorId}")]
        [Authorize]
        public IActionResult UpdateDoctorAvailability(int doctorId, [FromBody] List<UpdateDoctorAvailabilityDTO> timeSlotsDto)
        {
            var timeSlots = timeSlotsDto.Select(dto => new TimeSlot
            {
                TimeSlotID = dto.TimeSlotID,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                DoctorID = doctorId,
                IsBooked = dto.IsBooked, // Set the booking status
                PatientID = dto.PatientID // Set the patient ID
            }).ToList();

            // Check if any of the time slots are already booked
            var existingTimeSlots = _service.GetAvailableTimeSlots(doctorId);
            foreach (var timeSlot in timeSlots)
            {
                var existingTimeSlot = existingTimeSlots.FirstOrDefault(ts => ts.TimeSlotID == timeSlot.TimeSlotID);
                if (existingTimeSlot != null && existingTimeSlot.IsBooked)
                {
                    return BadRequest(new { message = $"Sorry, time slot {timeSlot.TimeSlotID} is already booked." });
                }
            }

            _service.UpdateDoctorAvailability(doctorId, timeSlots);
            return Ok(new { message = "Doctor availability updated successfully." });
        }
    }
}

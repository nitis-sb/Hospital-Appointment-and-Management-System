using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Services;
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
        public IActionResult UpdateDoctorAvailability(int doctorId, [FromBody] List<TimeSlot> timeSlots)
        {
            _service.UpdateDoctorAvailability(doctorId, timeSlots);
            return NoContent();
        }
    }
}

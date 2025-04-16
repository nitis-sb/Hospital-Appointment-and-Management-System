using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Hospital_Appointment_and_Management_System.Services;
using System.Security.Claims;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        //[Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationDTO notificationDto)
        {
            await _notificationService.CreateNotificationAsync(notificationDto);
            return Ok("Details Entered Successfully");

        }

        //[Authorize(Roles = "ADMIN", "USER")]
        [HttpGet("GetNotificationsByPatientId/{patientid}")]
        public async Task<IActionResult> GetNotifications(int patientid)
        {
            var notifications = await _notificationService.GetNotificationsByUserIdAsync(patientid);
            return Ok(notifications);
        }

        //[Authorize(Roles = "ADMIN", "USER")]
        [HttpDelete("GetNotificationsByPatientId/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            {
                var success = await _notificationService.DeleteNotificationAsync(notificationId);
                if (!success)
                {
                    return NotFound(new { message = "Notification ID does not exist." });
                }
                return Ok(new { message = "Notification deleted successfully." });
            }
        }
    }
}
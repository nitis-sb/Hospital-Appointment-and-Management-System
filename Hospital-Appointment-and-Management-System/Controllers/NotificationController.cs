using Microsoft.AspNetCore.Mvc;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Services;
using Microsoft.AspNetCore.Authorization;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationsController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationDTO notificationDto)
        {
            await _notificationService.CreateNotificationAsync(notificationDto);
            return Ok("Details Entered Successfuly");
        }

        [HttpGet("{patientid}")]
        public async Task<IActionResult> GetNotifications(int patientid)
        {
            var notifications = await _notificationService.GetNotificationsByUserIdAsync(patientid);
            return Ok(notifications);
        }

        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            await _notificationService.DeleteNotificationAsync(notificationId);
            return Ok("Notification Successfully Deleted");
        }
    }
}
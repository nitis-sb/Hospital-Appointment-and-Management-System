using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        }

        public async Task CreateNotificationAsync(NotificationDTO notificationDto)
        {

            var notification = new Notification
            {
                PatientID = notificationDto.PatientID,
                Message = notificationDto.Message,
                Timestamp = DateTime.UtcNow
            };

            await _notificationRepository.AddNotificationAsync(notification);
            await _notificationRepository.SaveChangesAsync();
        }


        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int patientid)
        {
            return await _notificationRepository.GetNotificationsByUserIdAsync(patientid);
        }

        //public async Task<Notification?> GetNotificationByIdAsync(int id)
        //{
        //    return await _notificationRepository.GetNotificationByIdAsync(id);
        //}

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return false;
            }

            await _notificationRepository.DeleteNotificationAsync(id);
            await _notificationRepository.SaveChangesAsync();
            return true;
        }
    }
}
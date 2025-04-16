using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(NotificationDTO notificationDto);
        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int patientid);
        Task<bool> DeleteNotificationAsync(int id);

    }
}

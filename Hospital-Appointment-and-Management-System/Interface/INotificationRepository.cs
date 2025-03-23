using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int patientid);
        Task<Notification?> GetNotificationByIdAsync(int id);
        Task AddNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
        Task SaveChangesAsync();
    }
}
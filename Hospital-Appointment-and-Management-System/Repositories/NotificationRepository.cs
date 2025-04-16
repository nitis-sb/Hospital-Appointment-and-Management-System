using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public class NotificationRepository : INotificationRepository

    {

        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)

        {

            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task AddNotificationAsync(Notification notification)

        {

            await _context.Notifications.AddAsync(notification);

        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int patientId)

        {

            return await _context.Notifications.Where(n => n.PatientID == patientId).ToListAsync();

        }

        public async Task<Notification?> GetNotificationByIdAsync(int id)

        {

            return await _context.Notifications.FindAsync(id);

        }

        public async Task DeleteNotificationAsync(int id)

        {

            var notification = await _context.Notifications.FindAsync(id);

            if (notification != null)

            {

                _context.Notifications.Remove(notification);

            }

        }

        public async Task SaveChangesAsync()

        {

            await _context.SaveChangesAsync();

        }

    }
}
using System.ComponentModel.DataAnnotations;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class DoctorSchedule
    {
        [Key]
        public required int DoctorID { get; set; }
        public string AvailableTimeSlots { get; set; }
    }
}

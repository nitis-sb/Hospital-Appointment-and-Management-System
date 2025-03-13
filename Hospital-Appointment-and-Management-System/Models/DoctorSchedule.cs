using System.ComponentModel.DataAnnotations;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class DoctorSchedule
    {
        [Key]
        public required int DoctorID { get; set; }
        public List<TimeSlot> AvailableTimeSlots { get; set; }
    }

    public class TimeSlot
    {
        [Key]
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class DoctorSchedule
    {
        [Key]
        public required int DoctorID { get; set; }
        public List<TimeSlot> AvailableTimeSlots { get; set; } = new List<TimeSlot>();
    }

    public class TimeSlot
    {
        [Key]
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [ForeignKey("DoctorSchedule")]
        public int DoctorID { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }

        public bool IsBooked { get; set; } // Indicates if the slot is booked
        public int? PatientID { get; set; } // Indicates which patient booked the slot
    }
}
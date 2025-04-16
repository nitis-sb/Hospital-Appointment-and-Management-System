using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class DoctorSchedule
    {
        [Key]
        public int DoctorScheduleID { get; set; }
        public int DoctorID { get; set; }
        public List<TimeSlot> AvailableTimeSlots { get; set; } = new List<TimeSlot>();
        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }
    }

    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
    }

    public class TimeSlot
    {
        [Key]
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }
        public int? PatientID { get; set; }
        public bool IsAvailable { get; set; }
        public string? CancelReason { get; set; }
        public virtual DoctorSchedule DoctorSchedule { get; set; }

        [ForeignKey("DoctorScheduleID")]
        public int DoctorScheduleID { get; set; }
    }
}

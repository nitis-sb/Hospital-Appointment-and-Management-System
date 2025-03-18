using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        [ForeignKey("PatientProfile")]
        public int PatientID { get; set; }
        [Required]
        [StringLength(200)]
        public string? Message { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
}

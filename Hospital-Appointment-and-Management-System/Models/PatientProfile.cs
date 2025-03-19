using System.ComponentModel.DataAnnotations;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class PatientProfile
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string ContactDetails { get; set; }

        public ICollection<MedicalHistory>? MedicalHistories { get; set; }

        public string UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class MedicalHistory
    {
        [Key]
        public int HistoryID { get; set; }

        [ForeignKey("PatientProfile")]
        public int PatientID { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(200)]
        public string Treatment { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }
        public PatientProfile? PatientProfile { get; set; }
    }
}
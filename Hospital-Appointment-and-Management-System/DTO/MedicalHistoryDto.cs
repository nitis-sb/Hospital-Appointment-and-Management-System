using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Appointment_and_Management_System.Dto
{
    public class MedicalHistoryDto
    {
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
    }
}

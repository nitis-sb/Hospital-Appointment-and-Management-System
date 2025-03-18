using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [ForeignKey("PatientProfile")]
        [Column("PatientID")]
        public int PatientID { get; set; }
        protected virtual PatientProfile PatientProfile { get; set; }

        [ForeignKey("DoctorSchedule")]
        [Column("DoctorID")]
        public int DoctorID { get; set; }
        protected virtual DoctorSchedule DoctorSchedule { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
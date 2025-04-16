using System;

namespace Hospital_Appointment_and_Management_System.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public int TimeSlotID { get; set; }
    }
}
namespace Hospital_Appointment_and_Management_System.DTOs
{
    public class UpdateDoctorAvailabilityDTO
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; } // Indicates if the slot is booked
        public int? PatientID { get; set; } // Indicates which patient booked the slot
    }
}
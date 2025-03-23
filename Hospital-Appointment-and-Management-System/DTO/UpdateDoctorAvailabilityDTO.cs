namespace Hospital_Appointment_and_Management_System.DTOs
{
    public class UpdateDoctorAvailabilityDTO
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }
        public int? PatientID { get; set; }
        public bool IsAvailable { get; set; } // New property to indicate availability
    }
}
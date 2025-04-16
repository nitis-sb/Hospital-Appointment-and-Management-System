namespace Hospital_Appointment_and_Management_System.DTO
{
    public class TimeSlotDto
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }
        public int? PatientID { get; set; }
        public bool IsAvailable { get; set; }
        public string? CancelReason { get; set; }
        public int DoctorScheduleID { get; set; }
    }
}

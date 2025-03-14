namespace Hospital_Appointment_and_Management_System.DTOs
{
    public class UpdateDoctorAvailabilityDTO
    {
        public int TimeSlotID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
namespace Hospital_Appointment_and_Management_System.DTO
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<TimeSlotDto> AvailableTimeSlots { get; set; } = new List<TimeSlotDto>();
    }
    
}

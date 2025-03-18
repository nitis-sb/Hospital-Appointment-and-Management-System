namespace Hospital_Appointment_and_Management_System.DTO
{
    public class UpdatePatient
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

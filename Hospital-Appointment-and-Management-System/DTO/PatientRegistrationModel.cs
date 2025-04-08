using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.DTO
{
    public class PatientRegistrationModel
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}

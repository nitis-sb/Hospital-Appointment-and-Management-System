using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IPatientService
    {
        Task<PatientProfile> RegisterPatientAsync(PatientRegistrationModel patientRegistration);
        Task<IdentityUser> LoginAsync(string email, string password);

        Task<PatientProfile> GetPatientProfileAsync(int patientId);
        Task<PatientProfile> UpdatePatientProfileAsync(int patientId, PatientProfile patientProfile);
        Task DeletePatientProfileAsync(int patientId);
        Task<PatientProfile> AddPatientAsync(PatientProfile patientProfile);
    }
}

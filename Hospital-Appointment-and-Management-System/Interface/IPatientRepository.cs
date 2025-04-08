using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IPatientRepository
    {
        Task<PatientProfile> AddPatientAsync(PatientProfile patientProfile);

        Task<int?> GetPatientIdByUsernameAsync(string username);
        Task<PatientProfile> GetPatientProfileAsync(string userId);
        Task<PatientProfile> 
            ProfileAsync(string userId, PatientProfile patientProfile);
        Task DeletePatientProfileAsync(int patientId);
        Task<PatientProfile> UpdatePatientProfileAsync(PatientProfile patientProfile);
    }

}

using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Hospital_Appointment_and_Management_System.Interface
{
    public interface IPatientRepository
    {
        Task<PatientProfile> AddPatientAsync(PatientProfile patientProfile);
        Task<PatientProfile> GetPatientProfileAsync(int patientId);
        Task<PatientProfile> 
            ProfileAsync(int patientId, PatientProfile patientProfile);
        Task DeletePatientProfileAsync(int patientId);
        Task<PatientProfile> UpdatePatientProfileAsync(PatientProfile patientProfile);
    }

}

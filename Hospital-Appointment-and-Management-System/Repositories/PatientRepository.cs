using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository(PatientDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PatientProfile> AddPatientAsync(PatientProfile patientProfile)
        {
            _context.PatientProfiles.Add(patientProfile);
            await _context.SaveChangesAsync();
            return patientProfile;
        }

        public async Task<PatientProfile> GetPatientProfileAsync(string userId)
        {
            var patientProfile = await _context.PatientProfiles
                .Include(p => p.MedicalHistories)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (patientProfile == null)
            {
                throw new System.Exception("Patient not found");
            }

            return patientProfile;

        }


        public async Task<PatientProfile> UpdatePatientProfileAsync(PatientProfile patientProfile)
        {
            _context.PatientProfiles.Update(patientProfile);
            await _context.SaveChangesAsync();
            return patientProfile;
        }

        public async Task<int?> GetPatientIdByUsernameAsync(string username)
        {
            var patient = await _context.PatientProfiles
                .FirstOrDefaultAsync(p => p.ContactDetails == username);

            return patient?.PatientID;
        }
        public async Task DeletePatientProfileAsync(int patientId)
        {
            var patientProfile = await _context.PatientProfiles.FindAsync(patientId);
            if (patientProfile == null)
            {
                throw new System.Exception("Patient not found");
            }

            _context.PatientProfiles.Remove(patientProfile);
            await _context.SaveChangesAsync();
        }

        // These methods will throw NotImplementedException as they are meant to be handled by the service
        public Task<PatientProfile> RegisterPatientAsync(PatientRegistrationModel patientRegistration)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<PatientProfile> ProfileAsync(int patientId, PatientProfile patientProfile)
        {
            throw new NotImplementedException();
        }

        public Task<PatientProfile> UpdatePatientProfileAsync(string userId, PatientProfile patientProfile)
        {
            throw new NotImplementedException();
        }

        public Task<PatientProfile> ProfileAsync(string userId, PatientProfile patientProfile)
        {
            throw new NotImplementedException();
        }
    }
}

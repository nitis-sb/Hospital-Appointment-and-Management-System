using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public PatientService(IPatientRepository patientRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<PatientProfile> RegisterPatientAsync(PatientRegistrationModel patientRegistration)
        {
            if (patientRegistration == null)
            {
                throw new ArgumentNullException(nameof(patientRegistration));
            }

            var user = new IdentityUser
            {
                UserName = patientRegistration.Email,
                Email = patientRegistration.Email
            };

            var result = await _userManager.CreateAsync(user, patientRegistration.Password);

            if (result.Succeeded)
            {
                var patientProfile = new PatientProfile
                {
                    Name = patientRegistration.Name,
                    DateOfBirth = patientRegistration.DateOfBirth,
                    ContactDetails = patientRegistration.Email,
                    // Map other properties as needed
                };

                return await _patientRepository.AddPatientAsync(patientProfile);
            }

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new System.Exception($"Failed to create user: {errors}");
        }

        public async Task<IdentityUser> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new System.Exception("User not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {
                return user;
            }

            throw new System.Exception("Invalid login attempt");
        }

        public async Task<PatientProfile> AddPatientAsync(PatientProfile patientProfile)
        {
            return await _patientRepository.AddPatientAsync(patientProfile);
        }

        public async Task<PatientProfile> GetPatientProfileAsync(int patientId)
        {
            return await _patientRepository.GetPatientProfileAsync(patientId);
        }

        public async Task<PatientProfile> UpdatePatientProfileAsync(int patientId, PatientProfile patientProfile)
        {
            var existingPatient = await _patientRepository.GetPatientProfileAsync(patientId);
            if (existingPatient == null)
            {
                throw new System.Exception("Patient not found");
            }

            existingPatient.Name = patientProfile.Name;
            existingPatient.DateOfBirth = patientProfile.DateOfBirth;
            existingPatient.ContactDetails = patientProfile.ContactDetails;

            return await _patientRepository.UpdatePatientProfileAsync(existingPatient);
        }

        public async Task DeletePatientProfileAsync(int patientId)
        {
            await _patientRepository.DeletePatientProfileAsync(patientId);
        }

        public Task<PatientProfile> UpdatePatientProfileAsync(int patientId, PatientProfile patientProfile, UpdatePatient updatePatient)
        {
            return UpdatePatientProfileAsync(patientId, patientProfile, updatePatient);
        }

    }
}

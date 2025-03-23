using System;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace Hospital_Appointment_and_Management_System.Tests
{
    [TestFixture]
    public class PatientServiceTests
    {
        private Mock<IPatientRepository> _mockRepository;
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<SignInManager<IdentityUser>> _mockSignInManager;
        private Mock<IMedicalHistoryService> _mockMedicalHistoryService;
        private PatientService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPatientRepository>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            _mockSignInManager = new Mock<SignInManager<IdentityUser>>(_mockUserManager.Object, null, null, null, null, null, null);
            _mockMedicalHistoryService = new Mock<IMedicalHistoryService>();
            _service = new PatientService(_mockRepository.Object, _mockUserManager.Object, _mockSignInManager.Object);
        }

        [Test]
        public async Task RegisterPatientAsync_CreatesNewPatient()
        {
            var patientRegistration = new PatientRegistrationModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                Name = "John Doe",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30))
            };

            var identityUser = new IdentityUser { Email = patientRegistration.Email, UserName = patientRegistration.Email };
            _mockUserManager.Setup(um => um.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.FindByEmailAsync(patientRegistration.Email)).ReturnsAsync(identityUser);

            var patientProfile = new PatientProfile { PatientID = 1, Name = patientRegistration.Name, DateOfBirth = patientRegistration.DateOfBirth, ContactDetails = patientRegistration.Email, UserId = identityUser.Id };
            _mockRepository.Setup(repo => repo.AddPatientAsync(It.IsAny<PatientProfile>())).ReturnsAsync(patientProfile);

            // Act
            var result = await _service.RegisterPatientAsync(patientRegistration);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PatientID, Is.EqualTo(patientProfile.PatientID));
        }

        [Test]
        public void RegisterPatientAsync_ThrowsException_WhenRegistrationFails()
        {
            // Arrange
            var patientRegistration = new PatientRegistrationModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                Name = "John Doe",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30))
            };

            _mockUserManager.Setup(um => um.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "User creation failed" }));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _service.RegisterPatientAsync(patientRegistration));
            Assert.That(ex.Message, Is.EqualTo("Failed to create user: User creation failed"));
        }

        [Test]
        public async Task LoginAsync_ReturnsUser_WhenLoginIsSuccessful()
        {
            // Arrange
            var email = "test@example.com";
            var password = "Password123!";
            var identityUser = new IdentityUser { Email = email, UserName = email };

            _mockUserManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync(identityUser);
            _mockSignInManager.Setup(sm => sm.PasswordSignInAsync(identityUser, password, false, false)).ReturnsAsync(SignInResult.Success);

            // Act
            var result = await _service.LoginAsync(email, password);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Email, Is.EqualTo(identityUser.Email));
        }

        [Test]
        public void LoginAsync_ThrowsException_WhenUserNotFound()
        {
            // Arrange
            var email = "test@example.com";
            var password = "Password123!";

            _mockUserManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync((IdentityUser)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _service.LoginAsync(email, password));
            Assert.That(ex.Message, Is.EqualTo("User not found"));
        }

        [Test]
        public void LoginAsync_ThrowsException_WhenLoginFails()
        {
            // Arrange
            var email = "test@example.com";
            var password = "Password123!";
            var identityUser = new IdentityUser { Email = email, UserName = email };

            _mockUserManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync(identityUser);
            _mockSignInManager.Setup(sm => sm.PasswordSignInAsync(identityUser, password, false, false)).ReturnsAsync(SignInResult.Failed);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _service.LoginAsync(email, password));
            Assert.That(ex.Message, Is.EqualTo("Invalid login attempt"));
        }
    }
}
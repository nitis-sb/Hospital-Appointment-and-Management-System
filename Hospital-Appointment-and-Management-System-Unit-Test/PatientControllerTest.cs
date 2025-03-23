using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.Controllers;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace PatientControllerTests
{
    [TestFixture]
    public class PatientControllerTests
    {
        private Mock<IPatientService> _mockService;
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<IConfiguration> _mockConfiguration;
        private PatientController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IPatientService>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            _mockConfiguration = new Mock<IConfiguration>();
            _controller = new PatientController(_mockService.Object, _mockConfiguration.Object, _mockUserManager.Object);
        }

        [Test]
        public async Task GetPatientProfile_ReturnsOkResult_WithPatientProfile()
        {
            // Arrange
            var patientProfile = new PatientProfile { PatientID = 1, UserId = "user1", Name = "John Doe" };
            _mockService.Setup(service => service.GetPatientProfileAsync(1)).ReturnsAsync(patientProfile);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user1")
            }, "mock"));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            // Act
            var result = await _controller.GetPatientProfile(1);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            var returnValue = okResult.Value as string;
            Assert.That(returnValue, Is.Not.Null);
            var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve, WriteIndented = true };
            var patientProfileResult = JsonSerializer.Deserialize<PatientProfile>(returnValue, options);
            Assert.That(patientProfileResult, Is.Not.Null);
            Assert.That(patientProfileResult.PatientID, Is.EqualTo(1));
        }

        [Test]
        public async Task GetPatientProfile_ReturnsNotFound_WhenPatientNotFound()
        {
            // Arrange
            _mockService.Setup(service => service.GetPatientProfileAsync(1)).ReturnsAsync((PatientProfile)null);

            // Act
            var result = await _controller.GetPatientProfile(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]

        public async Task GetPatientProfile_ReturnsForbid_WhenUserIdMismatch()
        {
            // Arrange
            var patientProfile = new PatientProfile { PatientID = 1, UserId = "user2", Name = "John Doe" };
            _mockService.Setup(service => service.GetPatientProfileAsync(1)).ReturnsAsync(patientProfile);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user1")
            }, "mock"));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            // Act
            var result = await _controller.GetPatientProfile(1);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult.StatusCode, Is.EqualTo(StatusCodes.Status403Forbidden));
        }
        [Test]
        public async Task RegisterPatient_ReturnsOkResult_WithPatientProfile()
        {
            // Arrange
            var patientRegistration = new PatientRegistrationModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                Name = "John Doe",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30))
            };
            var patientProfile = new PatientProfile { PatientID = 1, Name = "John Doe", DateOfBirth = patientRegistration.DateOfBirth, ContactDetails = patientRegistration.Email, UserId = "user1" };
            var identityUser = new IdentityUser { Email = patientRegistration.Email, UserName = patientRegistration.Email };

            _mockService.Setup(service => service.RegisterPatientAsync(patientRegistration)).ReturnsAsync(patientProfile);
            _mockUserManager.Setup(um => um.FindByEmailAsync(patientRegistration.Email)).ReturnsAsync(identityUser);
            _mockUserManager.Setup(um => um.AddToRoleAsync(identityUser, "USER")).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.RegisterPatient(patientRegistration);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            var returnValue = okResult.Value as PatientProfile;
            Assert.That(returnValue, Is.Not.Null);
            Assert.That(returnValue.PatientID, Is.EqualTo(1));
        }

        [Test]
        public async Task RegisterPatient_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Email is required");

            // Act
            var result = await _controller.RegisterPatient(new PatientRegistrationModel());

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task RegisterPatient_ReturnsBadRequest_WithExceptionMessage()
        {
            // Arrange
            var patientRegistration = new PatientRegistrationModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                Name = "John Doe",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30))
            };
            _mockService.Setup(service => service.RegisterPatientAsync(patientRegistration)).ThrowsAsync(new System.Exception("Registration failed"));

            // Act
            var result = await _controller.RegisterPatient(patientRegistration);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            var expectedMessage = new { message = "Registration failed" };
            Assert.That(badRequestResult.Value.ToString(), Is.EqualTo(expectedMessage.ToString()));
        }

        [Test]
        public async Task UpdatePatientProfile_ReturnsBadRequest_WhenPatientIdMismatch()
        {
            // Arrange
            var patientId = 1;
            var patientProfile = new PatientProfile { PatientID = 2 }; // Mismatched ID
            _controller.ModelState.Clear();

            // Act
            var result = await _controller.UpdatePatientProfile(patientId, patientProfile);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.EqualTo("Patient ID mismatch"));
        }

        [Test]
        public async Task UpdatePatientProfile_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var patientId = 1;
            var patientProfile = new PatientProfile { PatientID = 1 };
            _controller.ModelState.AddModelError("Error", "Invalid model state");

            // Act
            var result = await _controller.UpdatePatientProfile(patientId, patientProfile);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.InstanceOf<SerializableError>());
        }

        [Test]
        public async Task UpdatePatientProfile_ReturnsOk_WhenUpdateIsSuccessful()
        {
            // Arrange
            var patientId = 1;
            var patientProfile = new PatientProfile { PatientID = 1 };
            var updatedPatient = new PatientProfile { PatientID = 1, Name = "Updated Name" };
            _mockService.Setup(service => service.UpdatePatientProfileAsync(patientId, patientProfile)).ReturnsAsync(updatedPatient);
            _controller.ModelState.Clear();

            // Act
            var result = await _controller.UpdatePatientProfile(patientId, patientProfile);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(updatedPatient));
        }

        [Test]
        public async Task UpdatePatientProfile_ReturnsNotFound_WhenExceptionIsThrown()
        {
            // Arrange
            var patientId = 1;
            var patientProfile = new PatientProfile { PatientID = 1 };
            _mockService.Setup(service => service.UpdatePatientProfileAsync(patientId, patientProfile)).ThrowsAsync(new System.Exception("Patient not found"));
            _controller.ModelState.Clear();

            // Act
            var result = await _controller.UpdatePatientProfile(patientId, patientProfile);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundResult = result as NotFoundObjectResult;
            Assert.That(notFoundResult, Is.Not.Null);
            Assert.That(notFoundResult.Value, Is.Not.Null);

            var notFoundValue = notFoundResult.Value;
            Assert.That(notFoundValue.GetType().GetProperty("message"), Is.Not.Null);
            Assert.That(notFoundValue.GetType().GetProperty("message").GetValue(notFoundValue, null), Is.EqualTo("Patient not found"));
        }

    }
}
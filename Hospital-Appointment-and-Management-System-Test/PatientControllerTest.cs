using System.Security.Claims;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.Controllers;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Hospital_Appointment_and_Management_System.Tests
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
            var returnValue = okResult.Value as PatientProfile;
            Assert.That(returnValue, Is.Not.Null);
            Assert.That(returnValue.PatientID, Is.EqualTo(1));
        }

        [Test]
        public async Task GetPatientProfile_ReturnsNotFound_WhenPatientNotFound()
        {
            // Arrange
            _mockService.Setup(service => service.GetPatientProfileAsync(1)).ReturnsAsync((PatientProfile)null);

            // Act
            var result = await _controller.GetPatientProfile(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
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
            Assert.That(result, Is.InstanceOf<ForbidResult>());
        }
    }
}
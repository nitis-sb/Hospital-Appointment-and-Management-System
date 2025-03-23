using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Appointment_and_Management_System.DTOs;
using Hospital_Appointment_and_Management_System.Controllers;
using Hospital_Appointment_and_Management_System.Interfaces;

namespace AppointmentControllerTest {
    [TestFixture]
    public class AppointmentControllerTests
    {
        private Mock<IServiceAppointment> _mockService;
        private AppointmentController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IServiceAppointment>();
            _controller = new AppointmentController(_mockService.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOk_WithListOfAppointments()
        {
            // Arrange
            var appointments = new List<AppointmentDto>
        {
            new AppointmentDto { AppointmentID = 1, PatientID = 1, DoctorId = 1, AppointmentDate = DateTime.Now, Status = "Scheduled" },
            new AppointmentDto { AppointmentID = 2, PatientID = 2, DoctorId = 2, AppointmentDate = DateTime.Now, Status = "Completed" }
        };
            _mockService.Setup(service => service.GetAll()).ReturnsAsync(appointments);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(appointments));
        }

        [Test]
        public async Task GetElementById_ReturnsOk_WithAppointment()
        {
            // Arrange
            var appointment = new AppointmentDto { AppointmentID = 1, PatientID = 1, DoctorId = 1, AppointmentDate = DateTime.Now, Status = "Scheduled" };
            _mockService.Setup(service => service.GetElementById(1)).ReturnsAsync(appointment);

            // Act
            var result = await _controller.GetElementById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(appointment));
        }

        [Test]
        public async Task GetElementById_ReturnsNotFound_WhenAppointmentDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetElementById(1)).ReturnsAsync((AppointmentDto)null);

            // Act
            var result = await _controller.GetElementById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Create_ReturnsCreatedAtAction_WithCreatedAppointment()
        {
            // Arrange
            var appointmentDto = new AppointmentDto { AppointmentID = 1, PatientID = 1, DoctorId = 1, AppointmentDate = DateTime.Now, Status = "Scheduled" };
            _mockService.Setup(service => service.Create(appointmentDto)).ReturnsAsync(appointmentDto);

            // Act
            var result = await _controller.Create(appointmentDto);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.That(createdResult.Value, Is.EqualTo(appointmentDto));
            Assert.That(createdResult.RouteValues["id"], Is.EqualTo(appointmentDto.AppointmentID));
        }

        [Test]
        public async Task Create_ReturnsBadRequest_WhenAppointmentDtoIsNull()
        {
            // Act
            var result = await _controller.Create(null);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.EqualTo("Invalid appointment data."));
        }

        [Test]
        public async Task Update_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var appointmentDto = new AppointmentDto { AppointmentID = 1, PatientID = 1, DoctorId = 1, AppointmentDate = DateTime.Now, Status = "Scheduled" };
            _mockService.Setup(service => service.Update(appointmentDto)).Returns(Task.FromResult(appointmentDto));

            // Act
            var result = await _controller.Update(1, appointmentDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task Update_ReturnsBadRequest_WhenIdDoesNotMatchAppointmentID()
        {
            // Arrange
            var appointmentDto = new AppointmentDto { AppointmentID = 2, PatientID = 1, DoctorId = 1, AppointmentDate = DateTime.Now, Status = "Scheduled" };

            // Act
            var result = await _controller.Update(1, appointmentDto);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task Delete_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            // Arrange
            _mockService.Setup(service => service.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task Delete_ReturnsNotFound_WhenDeleteFails()
        {
            // Arrange
            _mockService.Setup(service => service.Delete(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}
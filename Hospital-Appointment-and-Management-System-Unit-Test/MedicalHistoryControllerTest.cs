using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAMS.Controllers;
using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MedicalHistoryControllerTests
{
    [TestFixture]
public class MedicalHistoryControllerTests
{
    private Mock<IMedicalHistoryRepository> _mockMedicalHistoryRepository;
    private MedicalHistoryController _controller;


    [SetUp]
    public void SetUp()
    {
        _mockMedicalHistoryRepository = new Mock<IMedicalHistoryRepository>();
        _controller = new MedicalHistoryController(_mockMedicalHistoryRepository.Object);
    }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose(); // Dispose the controller after each test
        }

        [Test]
    public void GetAllMedicalHistories_ReturnsOkWithMedicalHistories()
    {
        // Arrange
        var medicalHistories = new List<MedicalHistory>();
        _mockMedicalHistoryRepository.Setup(repo => repo.GetAllMedicalHistories()).Returns(medicalHistories);

        // Act
        var result = _controller.GetAllMedicalHistories();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.AreEqual(medicalHistories, okResult.Value);
    }

    [Test]
        public void GetMedicalHistoryByPatientId_ValidPatientId_ReturnsOkWithMedicalHistories()
        {
            // Arrange
            int patientId = 1;
            var medicalHistories = new List<MedicalHistory> { new MedicalHistory { HistoryID = 1, PatientID = patientId, Diagnosis = "Diagnosis", Treatment = "Treatment" } };
            _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryByPatientId(patientId)).Returns(medicalHistories);

            // Act
            var result = _controller.GetMedicalHistoryByPatientId(patientId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(medicalHistories, okResult.Value);
        }

        [Test]
    public void GetMedicalHistoryByPatientId_InvalidPatientId_ReturnsNotFound()
    {
        // Arrange
        int patientId = 1;
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryByPatientId(patientId)).Returns((List<MedicalHistory>)null);

        // Act
        var result = _controller.GetMedicalHistoryByPatientId(patientId);

        // Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result);
    }

    [Test]
    public void GetMedicalHistoryById_ValidHistoryId_ReturnsOkWithMedicalHistory()
    {
        // Arrange
        int historyId = 1;
        var medicalHistory = new MedicalHistory();
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns(medicalHistory);

        // Act
        var result = _controller.GetMedicalHistoryById(historyId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.AreEqual(medicalHistory, okResult.Value);
    }

    [Test]
    public void GetMedicalHistoryById_InvalidHistoryId_ReturnsNotFound()
    {
        // Arrange
        int historyId = 1;
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns((MedicalHistory)null);

        // Act
        var result = _controller.GetMedicalHistoryById(historyId);

        // Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result);
    }

    [Test]
    public void AddMedicalHistory_ValidMedicalHistoryDto_ReturnsCreatedAtAction()
    {
        // Arrange
        var medicalHistoryDto = new MedicalHistoryDto { HistoryID = 1, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };
        var medicalHistory = new MedicalHistory { HistoryID = 1, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };
        _mockMedicalHistoryRepository.Setup(repo => repo.AddMedicalHistory(It.IsAny<MedicalHistory>()));

        // Act
        var result = _controller.AddMedicalHistory(medicalHistoryDto);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result);
        var createdAtActionResult = result as CreatedAtActionResult;
        Assert.AreEqual(nameof(MedicalHistoryController.GetMedicalHistoryById), createdAtActionResult.ActionName);
        Assert.AreEqual(medicalHistory.HistoryID, ((MedicalHistory)createdAtActionResult.Value).HistoryID);
    }

    [Test]
    public void AddMedicalHistory_NullMedicalHistoryDto_ReturnsBadRequest()
    {
        // Act
        var result = _controller.AddMedicalHistory(null);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public void UpdateMedicalHistory_ValidHistoryId_ReturnsNoContent()
    {
        // Arrange
        int historyId = 1;
        var medicalHistory = new MedicalHistory { HistoryID = historyId, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns(medicalHistory);
        _mockMedicalHistoryRepository.Setup(repo => repo.UpdateMedicalHistory(medicalHistory));

        // Act
        var result = _controller.UpdateMedicalHistory(historyId, medicalHistory);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public void UpdateMedicalHistory_InvalidHistoryId_ReturnsBadRequest()
    {
        // Arrange
        int historyId = 1;
        var medicalHistory = new MedicalHistory { HistoryID = 2, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };

        // Act
        var result = _controller.UpdateMedicalHistory(historyId, medicalHistory);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public void UpdateMedicalHistory_HistoryNotFound_ReturnsNotFound()
    {
        // Arrange
        int historyId = 1;
        var medicalHistory = new MedicalHistory { HistoryID = historyId, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns((MedicalHistory)null);

        // Act
        var result = _controller.UpdateMedicalHistory(historyId, medicalHistory);

        // Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result);
    }

    [Test]
    public void DeleteMedicalHistory_ValidHistoryId_ReturnsNoContent()
    {
        // Arrange
        int historyId = 1;
        var medicalHistory = new MedicalHistory { HistoryID = historyId, PatientID = 1, Diagnosis = "Diagnosis", Treatment = "Treatment" };
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns(medicalHistory);
        _mockMedicalHistoryRepository.Setup(repo => repo.DeleteMedicalHistory(historyId));

        // Act
        var result = _controller.DeleteMedicalHistory(historyId);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public void DeleteMedicalHistory_HistoryNotFound_ReturnsNotFound()
    {
        // Arrange
        int historyId = 1;
        _mockMedicalHistoryRepository.Setup(repo => repo.GetMedicalHistoryById(historyId)).Returns((MedicalHistory)null);

        // Act
        var result = _controller.DeleteMedicalHistory(historyId);

        // Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result);
    }
}
}

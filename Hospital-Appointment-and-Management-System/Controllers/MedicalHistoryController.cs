using AutoMapper;
using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : Controller
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;


        public MedicalHistoryController(IMedicalHistoryRepository medicalHistoryRepository)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
           
        }

        [HttpGet]
        public IActionResult GetAllMedicalHistories()
        {
            var medicalHistories = _medicalHistoryRepository.GetAllMedicalHistories();
            return Ok(medicalHistories);
        }

        [HttpGet("{patientId}")]
        public IActionResult GetMedicalHistoryByPatientId(int patientId)
        {
            var medicalHistories = _medicalHistoryRepository.GetMedicalHistoryByPatientId(patientId);
            if (medicalHistories == null || !medicalHistories.Any())
            {
                return NotFound($"No medical history found for patient ID: {patientId}");
            }
            return Ok(medicalHistories);
        }

        [HttpGet("history/{historyId}")]
        public IActionResult GetMedicalHistoryById(int historyId)
        {
            var medicalHistory = _medicalHistoryRepository.GetMedicalHistoryById(historyId);
            if (medicalHistory == null)
            {
                return NotFound($"No medical history found with ID: {historyId}");
            }
            return Ok(medicalHistory);
        }


        [HttpPost]
        public IActionResult AddMedicalHistory([FromBody] MedicalHistoryDto medicalHistoryDto)
        {
            if (medicalHistoryDto == null)
            {
                return BadRequest("Medical history data is required.");
            }

            // Manually map the properties from MedicalHistoryDto to MedicalHistory
            var medicalHistory = new MedicalHistory
            {
                HistoryID = medicalHistoryDto.HistoryID,
                PatientID = medicalHistoryDto.PatientID,
                Diagnosis = medicalHistoryDto.Diagnosis,
                Treatment = medicalHistoryDto.Treatment
                // Add mapping for all other relevant properties
            };

            _medicalHistoryRepository.AddMedicalHistory(medicalHistory);

            return CreatedAtAction(nameof(GetMedicalHistoryById), new { historyId = medicalHistory.HistoryID }, medicalHistory);
        }

        [HttpPut("{historyId}")]
            public IActionResult UpdateMedicalHistory(int historyId, [FromBody] MedicalHistory medicalHistory)
        {
            if (historyId != medicalHistory.HistoryID)
            {
                return BadRequest("Invalid medical history data.");
            }

            var existingHistory = _medicalHistoryRepository.GetMedicalHistoryById(historyId);

            if (existingHistory == null)
            {
                return NotFound($"No medical history found with ID: {historyId}");
            }

            else
            {
                _medicalHistoryRepository.UpdateMedicalHistory(medicalHistory);
            }

            return NoContent();
        }

        [HttpDelete("{historyId}")]
        public IActionResult DeleteMedicalHistory(int historyId)
        {
            var existingHistory = _medicalHistoryRepository.GetMedicalHistoryById(historyId);
            if (existingHistory == null)
            {
                return NotFound($"No medical history found with ID: {historyId}");
            }

            _medicalHistoryRepository.DeleteMedicalHistory(historyId);
            return NoContent();
        }
    }
}

using AutoMapper;
using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using System.Collections.Generic;

namespace Hospital_Appointment_and_Management_System.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IMapper _mapper;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IMapper mapper)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<MedicalHistory> GetAllMedicalHistories()
        {
            return _medicalHistoryRepository.GetAllMedicalHistories();
        }

        public IEnumerable<MedicalHistory> GetMedicalHistoryByPatientId(int patientId)
        {
            return _medicalHistoryRepository.GetMedicalHistoryByPatientId(patientId);
        }

        public MedicalHistory GetMedicalHistoryById(int historyId)
        {
            return _medicalHistoryRepository.GetMedicalHistoryById(historyId);
        }

        public void AddMedicalHistory(MedicalHistoryDto medicalHistoryDto)
        {
            var medicalHistory = _mapper.Map<MedicalHistory>(medicalHistoryDto);
            _medicalHistoryRepository.AddMedicalHistory(medicalHistory);
        }

        public void UpdateMedicalHistory(int historyId, MedicalHistory medicalHistory)
        {
            if (historyId != medicalHistory.HistoryID)
            {
                throw new ArgumentException("Invalid medical history data.");
            }

            var existingHistory = _medicalHistoryRepository.GetMedicalHistoryById(historyId);
            if (existingHistory == null)
            {
                throw new KeyNotFoundException($"No medical history found with ID: {historyId}");
            }

            _medicalHistoryRepository.UpdateMedicalHistory(medicalHistory);
        }

        public void DeleteMedicalHistory(int historyId)
        {
            var existingHistory = _medicalHistoryRepository.GetMedicalHistoryById(historyId);
            if (existingHistory == null)
            {
                throw new KeyNotFoundException($"No medical history found with ID: {historyId}");
            }

            _medicalHistoryRepository.DeleteMedicalHistory(historyId);
        }
    }
}
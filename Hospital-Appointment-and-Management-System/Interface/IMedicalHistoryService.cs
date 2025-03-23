using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Models;
using System.Collections.Generic;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface IMedicalHistoryService
    {
        IEnumerable<MedicalHistory> GetAllMedicalHistories();
        IEnumerable<MedicalHistory> GetMedicalHistoryByPatientId(int patientId);
        MedicalHistory GetMedicalHistoryById(int historyId);
        void AddMedicalHistory(MedicalHistoryDto medicalHistoryDto);
        void UpdateMedicalHistory(int historyId, MedicalHistory medicalHistory);
        void DeleteMedicalHistory(int historyId);
    }
}
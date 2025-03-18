using Hospital_Appointment_and_Management_System.Models;

namespace Hospital_Appointment_and_Management_System.Interfaces
{
    public interface IMedicalHistoryRepository
    {
        IEnumerable<MedicalHistory> GetAllMedicalHistories();

        IEnumerable<MedicalHistory> GetMedicalHistoryByPatientId(int patientId);

        MedicalHistory GetMedicalHistoryById(int historyId);

        void AddMedicalHistory(MedicalHistory medicalHistory);

        void UpdateMedicalHistory(MedicalHistory medicalHistory);

        void DeleteMedicalHistory(int historyId);
    }
}

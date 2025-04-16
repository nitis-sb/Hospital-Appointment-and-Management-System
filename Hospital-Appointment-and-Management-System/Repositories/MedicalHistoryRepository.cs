using AutoMapper;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Models;
using Hospital_Appointment_and_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Repository
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly ApplicationDbContext _context;
       
        public MedicalHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public void AddMedicalHistory(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Add(medicalHistory);
            _context.SaveChanges();
        }
        public void DeleteMedicalHistory(int historyId)
        {
            var historyToDelete = _context.MedicalHistories
                                          .FirstOrDefault(mh => mh.HistoryID == historyId);

            if (historyToDelete != null)
            {
                _context.MedicalHistories.Remove(historyToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MedicalHistory> GetAllMedicalHistories()
        {
            return _context.MedicalHistories.ToList();
        }

        public MedicalHistory GetMedicalHistoryById(int historyId)
        {
            return _context.MedicalHistories
                           .FirstOrDefault(mh => mh.HistoryID == historyId);
        }

        public IEnumerable<MedicalHistory> GetMedicalHistoryByPatientId(int patientId)
        {
            return _context.MedicalHistories
                           .Where(mh => mh.PatientID == patientId)
                           .ToList();
        }

        public void UpdateMedicalHistory(MedicalHistory medicalHistory)
        {
            var existingHistory = _context.MedicalHistories
                                          .FirstOrDefault(mh => mh.HistoryID == medicalHistory.HistoryID);

            if (existingHistory != null)
            {
                // Update the relevant fields
                existingHistory.Diagnosis = medicalHistory.Diagnosis;
                existingHistory.Treatment = medicalHistory.Treatment;
                existingHistory.DateOfVisit = medicalHistory.DateOfVisit;

                // Mark the entity as modified
                _context.MedicalHistories.Update(existingHistory);

                _context.SaveChanges();
            }
        }
    }
}


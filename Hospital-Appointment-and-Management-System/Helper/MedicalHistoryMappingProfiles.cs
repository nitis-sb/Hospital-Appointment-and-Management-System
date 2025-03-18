using AutoMapper;
using Hospital_Appointment_and_Management_System.Dto;
using Hospital_Appointment_and_Management_System.Models;

namespace HAMS.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MedicalHistoryDto, MedicalHistory>();
        }
    }
}

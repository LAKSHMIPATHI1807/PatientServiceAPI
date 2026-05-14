using AutoMapper;
using PatientServiceAPI.Entities;
using PatientServiceAPI.DTOs;

namespace PatientServiceAPI.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<CreatePatientDto,  Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<Patient, ReadPatientDto>();
        }
    }
}

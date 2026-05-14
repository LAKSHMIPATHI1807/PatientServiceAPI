using Microsoft.EntityFrameworkCore;
using PatientServiceAPI.Entities;
using PatientServiceAPI.DTOs;
using PatientServiceAPI.Profiles;
using PatientServiceAPI.Repositories;
using AutoMapper;

namespace PatientServiceAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreatePatientAsync(CreatePatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _repository.CreatePatientAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _repository.DeletePatientAsync(id);
        }

        public async Task<List<ReadPatientDto>> GetAllPatientsAsync()
        {
            var patients = await _repository.GetAllPatientsAsync();
            var dtos = _mapper.Map<List<ReadPatientDto>>(patients);
            return dtos;
        }

        public async Task<ReadPatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetPatientByIdAsync(id);
            return _mapper.Map<ReadPatientDto>(patient);
        }

        public async Task<ReadPatientDto> GetPatientByNameAsync(string name)
        {
            var patient = await _repository.GetPatientByNameAsync(name);
            return _mapper.Map<ReadPatientDto>(patient);
        }

        public async Task UpdatePatientAsync(int id, UpdatePatientDto patientDto)
        {
            var patient = await _repository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return;
            }
            _mapper.Map(patientDto, patient);
            await _repository.UpdatePatientAsync(patient);
        }
    }
}

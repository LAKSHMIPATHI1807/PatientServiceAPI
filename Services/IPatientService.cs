using PatientServiceAPI.DTOs;

namespace PatientServiceAPI.Services
{
    public interface IPatientService
    {
        Task CreatePatientAsync(CreatePatientDto patient);
        Task<List<ReadPatientDto>> GetAllPatientsAsync();
        Task<ReadPatientDto> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(int id, UpdatePatientDto patient);
        Task DeletePatientAsync(int id);
        Task<ReadPatientDto> GetPatientByNameAsync(string name);
    }
}

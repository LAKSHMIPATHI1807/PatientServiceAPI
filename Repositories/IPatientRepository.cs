using PatientServiceAPI.Entities;
using PatientServiceAPI.Data;

namespace PatientServiceAPI.Repositories
{
    public interface IPatientRepository
    {
        Task CreatePatientAsync(Patient patient);
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);

        Task<Patient> GetPatientByNameAsync(string name);
    }
}

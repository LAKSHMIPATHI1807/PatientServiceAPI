using Microsoft.EntityFrameworkCore;
using PatientServiceAPI.Data;
using PatientServiceAPI.Entities;
using PatientServiceAPI.Repositories;

namespace PatientServiceAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _patientDbContext;
        public PatientRepository(PatientDbContext patientDbContext)
        {
            _patientDbContext = patientDbContext;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            _patientDbContext.Patients.Add(patient);
            await _patientDbContext.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = _patientDbContext.Patients.FirstOrDefault(p => p.PatientId == id);
            if (patient != null)
            {
                _patientDbContext.Remove(patient);
                await _patientDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientDbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _patientDbContext.Patients.FindAsync(id);
            //if (patient == null)
            //{
            //    return;
            //}
            return patient;
        }

        public async Task<Patient> GetPatientByNameAsync(string name)
        {
            var patient = await _patientDbContext.Patients.FirstOrDefaultAsync(p => p.Name == name);
            return patient;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _patientDbContext.Patients.Update(patient);
            await _patientDbContext.SaveChangesAsync();
        }
    }
}

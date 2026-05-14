using PatientServiceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace PatientServiceAPI.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
    }
}

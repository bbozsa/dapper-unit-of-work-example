using DapperUofW.Example.Core.Domain.Entities;

namespace DapperUofW.Example.Core.Gateways.Persistence.Repository
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task<Patient> GetAsync(Guid customerId);
        Task DeleteAll();
    }
}

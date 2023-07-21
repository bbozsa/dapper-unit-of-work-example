using DapperUofW.Example.Core.Domain.Entities;

namespace DapperUofW.Example.Core.Gateways.Persistence.Repository
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer  customer);
        Task<Customer> GetAsync(Guid customerId);
    }
}

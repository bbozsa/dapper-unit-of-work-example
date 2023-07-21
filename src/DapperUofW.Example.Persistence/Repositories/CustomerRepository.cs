using Dapper;
using DapperUofW.Example.Core.Domain.Entities;
using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Extensions;

namespace DapperUofW.Example.Persistence.Repositories
{
    internal class CustomerRepository : Repository, ICustomerRepository
    {

        public CustomerRepository(IUnitOfWork unitOfWork)
        {
            ConnectionDetails = unitOfWork.GetConnectionDetails();
        }

        public async Task AddAsync(Customer customer)
        {
            const string query =
                @"INSERT INTO [DapperUofWExample].[Customer] (
                    [Id],
                    [FirstName],
                    [LastName],
                    [Email])
                VALUES (
                    @Id,
                    @FirstName,
                    @LastName,
                    @Email);";

            var affectedRows = await ConnectionDetails.Connection.ExecuteAsync(query, customer,
                transaction: ConnectionDetails.Transaction);

            if (affectedRows < 1)
            {
                throw new InvalidOperationException("No rows were affected.");
            }
        }

        public async Task<Customer> GetAsync(Guid customerId)
        {
            const string query =
                @"SELECT
                        [Id],
                        [FirstName],
                        [LastName],
                        [Email],
                        [ConcurrencyToken]    
                FROM [DapperUofWExample].[Customer]
                WHERE [Id] = @Id;";

            var result = await ConnectionDetails.Connection.QueryAsync<Customer>(
                sql: query, 
                param: new {Id = customerId},
                transaction: ConnectionDetails.Transaction);
            return result.SingleOrDefault();
        }
    }
}

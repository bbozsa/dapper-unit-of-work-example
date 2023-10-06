using Dapper;
using DapperUofW.Example.Core.Domain.Entities;
using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Extensions;

namespace DapperUofW.Example.Persistence.Repositories
{
    internal class PatientRepository : Repository, IPatientRepository
    {

        public PatientRepository(IUnitOfWork unitOfWork)
        {
            ConnectionDetails = unitOfWork.GetConnectionDetails();
        }

        public async Task AddAsync(Patient patient)
        {
            const string query =
                @"INSERT INTO [DapperUofWExample].[Patient] (
                    [Id],
                    [FirstName],
                    [LastName],
                    [Email])
                VALUES (
                    @Id,
                    @FirstName,
                    @LastName,
                    @Email);";

            var affectedRows = await ConnectionDetails.Connection.ExecuteAsync(query, patient,
                transaction: ConnectionDetails.Transaction);

            if (affectedRows < 1)
            {
                throw new InvalidOperationException("No rows were affected.");
            }
        }

        public async Task<Patient> GetAsync(Guid customerId)
        {
            const string query =
                @"SELECT
                        [Id],
                        [FirstName],
                        [LastName],
                        [Email],
                        [ConcurrencyToken]    
                FROM [DapperUofWExample].[Patient]
                WHERE [Id] = @Id;";

            var result = await ConnectionDetails.Connection.QueryAsync<Patient>(
                sql: query,
                param: new { Id = customerId },
                transaction: ConnectionDetails.Transaction);
            return result.SingleOrDefault();
        }

        public Task DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}

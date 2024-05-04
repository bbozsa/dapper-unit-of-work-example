using DapperUofW.Example.Core.Gateways.Persistence;
using Microsoft.Extensions.Configuration;

namespace DapperUofW.Example.Persistence
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly string? _connectionString;

        public DbContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DapperUofWExampleConnectionString");
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException(nameof(_connectionString), "Database connection string is null or empty.");
            }
        }

        public async Task<IDbContext> CreateAsync()
        {
            return await DbContext.CreateAsync(_connectionString);
        }
    }
}

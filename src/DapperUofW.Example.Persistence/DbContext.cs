using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperUofW.Example.Persistence
{
    public sealed class DbContext : IDbContext
    {
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;

        private readonly IDbConnection _connection;

        private DbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            UnitOfWork = new UnitOfWork(_connection);
        }

        private async Task<DbContext> OpenConnectionAsync()
        { 
            await ((SqlConnection)_connection).OpenAsync();
            return this;
        }

        public static Task<DbContext> CreateAsync(string connectionString)
        {
            var dbContext = new DbContext(connectionString);
            return dbContext.OpenConnectionAsync();
        }

        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(UnitOfWork);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(UnitOfWork);


        public IUnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            UnitOfWork?.Dispose();
            _connection?.Dispose();
        }
    }
}

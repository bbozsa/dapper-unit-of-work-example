namespace DapperUofW.Example.Core.Gateways.Persistence
{
    public interface IDbContext : IDisposable
    {
        // ICustomerRepository CustomerRepository { get; }
        // IOrderRepository OrderRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}

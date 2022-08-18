namespace DapperUofW.Example.Core.Gateways.Persistence
{
    public interface IDbContextFactory
    {
        Task<IDbContext> CreateAsync();
    }
}

namespace DapperUofW.Example.Core.Gateways.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
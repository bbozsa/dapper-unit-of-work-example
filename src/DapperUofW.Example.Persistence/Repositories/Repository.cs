namespace DapperUofW.Example.Persistence.Repositories
{
    public abstract class Repository
    {
        internal IConnectionDetails ConnectionDetails { get; set; }
    }
}

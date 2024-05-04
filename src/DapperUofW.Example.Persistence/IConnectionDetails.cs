using System.Data;

namespace DapperUofW.Example.Persistence
{
    internal interface IConnectionDetails
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}

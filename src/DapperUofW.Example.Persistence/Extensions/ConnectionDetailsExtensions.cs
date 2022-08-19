using DapperUofW.Example.Core.Gateways.Persistence;

namespace DapperUofW.Example.Persistence.Extensions
{
    internal static class ConnectionDetailsExtensions
    {
        public static IConnectionDetails GetConnectionDetails(this IUnitOfWork unitOfWork)
        {
            return unitOfWork as IConnectionDetails;
        }
    }
}

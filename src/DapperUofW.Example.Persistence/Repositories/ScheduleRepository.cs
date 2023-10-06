using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Extensions;

namespace DapperUofW.Example.Persistence.Repositories
{
    internal class ScheduleRepository : Repository, IScheduleRepository
    {
        public ScheduleRepository(IUnitOfWork unitOfWork)
        {
            ConnectionDetails = unitOfWork.GetConnectionDetails();
        }
    }
}

using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Extensions;

namespace DapperUofW.Example.Persistence.Repositories
{
    internal class AppointmentRepository : Repository, IAppointmentRepository
    {
        public AppointmentRepository(IUnitOfWork unitOfWork)
        {
            ConnectionDetails = unitOfWork.GetConnectionDetails();
        }
    }
}

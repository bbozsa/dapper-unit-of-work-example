using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Extensions;

namespace DapperUofW.Example.Persistence.Repositories
{
    internal class PhysicianRepository : Repository, IPhysicianRepository
    {
        public PhysicianRepository(IUnitOfWork unitOfWork)
        {
            ConnectionDetails = unitOfWork.GetConnectionDetails();
        }
    }
}

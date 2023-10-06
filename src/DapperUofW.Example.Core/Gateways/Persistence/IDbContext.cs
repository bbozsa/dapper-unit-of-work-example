using DapperUofW.Example.Core.Gateways.Persistence.Repository;

namespace DapperUofW.Example.Core.Gateways.Persistence
{
    public interface IDbContext : IDisposable
    {
        IPatientRepository PatientRepository { get; }
        IPhysicianRepository PhysicianRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IScheduleRepository ScheduleRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}

using DapperUofW.Example.Core.Gateways.Persistence;
using DapperUofW.Example.Core.Gateways.Persistence.Repository;
using DapperUofW.Example.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperUofW.Example.Persistence
{
    public sealed class DbContext : IDbContext
    {
        private IPatientRepository _patientRepository;
        private IPhysicianRepository _physicianRepository;
        private IAppointmentRepository _appointmentRepository;
        private IScheduleRepository _scheduleRepository;

        private readonly IDbConnection _connection;

        private DbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            UnitOfWork = new UnitOfWork(_connection);
        }

        private async Task<DbContext> OpenConnectionAsync()
        {
            await ((SqlConnection)_connection).OpenAsync();
            return this;
        }

        public static Task<DbContext> CreateAsync(string connectionString)
        {
            var dbContext = new DbContext(connectionString);
            return dbContext.OpenConnectionAsync();
        }

        public IPatientRepository PatientRepository => _patientRepository ??= new PatientRepository(UnitOfWork);
        public IPhysicianRepository PhysicianRepository => _physicianRepository ??= new PhysicianRepository(UnitOfWork);
        public IAppointmentRepository AppointmentRepository => _appointmentRepository ??= new AppointmentRepository(UnitOfWork);
        public IScheduleRepository ScheduleRepository => _scheduleRepository ??= new ScheduleRepository(UnitOfWork);


        public IUnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            UnitOfWork?.Dispose();
            _connection?.Dispose();
        }
    }
}

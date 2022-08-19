using DapperUofW.Example.Core.Gateways.Persistence;
using System.Data;

namespace DapperUofW.Example.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork, IConnectionDetails
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _transaction = null;
        }

        IDbConnection IConnectionDetails.Connection => _connection;

        IDbTransaction IConnectionDetails.Transaction => _transaction;

        public void Begin()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Cannot begin transaction. Transaction already exists.");
            }

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Cannot complete commit. Transaction is null.");
            }

            _transaction.Commit();
            DisposeTransaction();
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Cannot complete rollback. Transaction is null.");
            }

            _transaction.Rollback();
            DisposeTransaction();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            DisposeTransaction();
        }
    }
}
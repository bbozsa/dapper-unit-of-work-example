namespace DapperUofW.Example.Database.Migration.Interfaces
{
    public interface IMigrationService
    {
        bool Migrate(string connectionString);
    }
}

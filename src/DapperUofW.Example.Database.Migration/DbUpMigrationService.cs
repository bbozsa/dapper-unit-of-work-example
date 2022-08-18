using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DapperUofW.Example.Database.Migration.Interfaces;
using DbUp;

namespace DapperUofW.Example.Database.Migration
{
    public class DbUpMigrationService : IMigrationService
    {
        public bool Migrate(string connectionString)
        {            
            EnsureDatabase.For.PostgresqlDatabase(connectionString);
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value: "Success!");
            Console.ResetColor();
            return 0;
        }
    }
}

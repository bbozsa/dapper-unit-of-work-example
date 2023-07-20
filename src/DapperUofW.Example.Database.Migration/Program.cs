using DbUp;
using System.Reflection;

namespace DapperUofW.Example.Database.Migration
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var connectionString = args.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString), "Database connection string is null or empty.");
                }

                EnsureDatabase.For.SqlDatabase(connectionString);

                var upgradeEngine =
                    DeployChanges.To
                        .SqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                        .LogToConsole()
                        .Build();

                var result = upgradeEngine.PerformUpgrade();
                if (!result.Successful)
                {
                    WriteErrorMessage(result.Error.Message);
                    return -1;
                }

                WriteSuccessMessage("Success!");
                return 0;
            }
            catch (Exception exception)
            {
                WriteErrorMessage(exception.Message);
                return -1;
            }
        }

        private static void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DapperUofW.Example.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<App>()?.Run(args)!;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false)
            //    .AddEnvironmentVariables()
            //    .Build();

           // services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            // Register Services
            //
            //services.AddSingleton<IPassiveRfidReaderFactory, PassiveRfidReaderFactory>();
            //services.AddSingleton<INurevaApiService, NurevaApiService>();
            //services.AddSingleton<IGoogleAssistantService, GoogleAssistantService>();
            //services.AddSingleton<IProcessingPipeline, ProcessingPipeline>();

            // add app
            services.AddTransient<App>();
        }
    }
}
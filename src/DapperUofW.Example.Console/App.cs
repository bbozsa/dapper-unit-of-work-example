using Microsoft.Extensions.Logging;

namespace DapperUofW.Example.Console
{
    internal class App
    {
        private readonly ILogger<App> _logger;
        
        public App(ILogger<App> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Welcome to NuSpeech...");

           // await _processingPipeline.ProcessAudio();

            _logger.LogInformation("Finished!");
            await Task.CompletedTask;
        }
    }
}

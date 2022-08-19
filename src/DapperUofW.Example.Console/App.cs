using DapperUofW.Example.Core.Gateways.Persistence;
using Microsoft.Extensions.Logging;

namespace DapperUofW.Example.Console
{
    internal class App
    {
        private readonly ILogger<App> _logger;
        private readonly IDbContextFactory _dbContextFactory;

        public App(ILogger<App> logger, IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task Run(string[] args)
        {
            using (var dbContext = await _dbContextFactory.CreateAsync())
            {
                dbContext.UnitOfWork.Begin();
                dbContext.UnitOfWork.Rollback();

            }
            await Task.CompletedTask;
        }
    }
}

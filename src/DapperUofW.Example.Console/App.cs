using DapperUofW.Example.Core.Domain.Entities;
using DapperUofW.Example.Core.Gateways.Persistence;

namespace DapperUofW.Example.Console
{
    internal class App
    {
        private readonly IDbContextFactory _dbContextFactory;

        public App(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task Run()
        {
            using (var dbContext = await _dbContextFactory.CreateAsync())
            {
                var newCustomer = Customer.Create("John", "Doe", "JohnDoe@email.com");

                
                
                dbContext.UnitOfWork.Begin();
                await dbContext.CustomerRepository.AddAsync(newCustomer);
                dbContext.UnitOfWork.Commit();

                var existingCustomer = await dbContext.CustomerRepository.GetAsync(Guid.Empty);

            }
            await Task.CompletedTask;
        }
    }
}

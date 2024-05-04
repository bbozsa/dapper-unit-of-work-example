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
            //using (var dbContext = await _dbContextFactory.CreateAsync())
            //{
            //    dbContext.UnitOfWork.Begin();
            //    await dbContext.PatientRepository.DeleteAll();
            //    dbContext.UnitOfWork.Commit();
            //}

            //var newCustomer = Patient.Create("John", "Doe", "JohnDoe@email.com");
            //var newOrder1 = Order.Create("Item 1", 100);
            //var newOrder2 = Order.Create("Item 2", 200);

            //using (var dbContext = await _dbContextFactory.CreateAsync())
            //{



            //    dbContext.UnitOfWork.Begin();
            //    await dbContext.PatientRepository.AddAsync(newCustomer);
            //    dbContext.UnitOfWork.Commit();

            //    var existingCustomer = await dbContext.PatientRepository.GetAsync(Guid.Empty);

            //}
            await Task.CompletedTask;
        }
    }
}

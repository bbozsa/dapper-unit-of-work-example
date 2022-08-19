//namespace DapperUofW.Example.Persistence.Repositories
//{
//    public class UserRepository : Repository, IUserRepository
//    {
//        public UserRepository(IUnitOfWork unitOfWork)
//        {
//            ConnectionDetails = unitOfWork.GetConnectionDetails();
//        }

//        public async Task<IList<User>> GetPaginatedUsersAsync(PaginationSettingsDto paginationSettings)
//        {
//            const string query =
//                @"SELECT
//                    [U].[Id],
//                    [U].[IdentityProviderId],
//                    [U].[FirstName],
//                    [U].[LastName],
//                    [U].[Email],
//                    [U].[IsVerified],
//                    [U].[ConcurrencyToken]
//                  FROM [InventoryTracker].[User] AS [U]
//                  ORDER BY [U].[Email]
//                  OFFSET @Offset ROWS
//                  FETCH NEXT @PageSize ROWS ONLY;";

//                return (await ConnectionDetails.Connection.QueryAsync<User>(
//                sql: query,
//                param: new
//                {
//                    PageSize = paginationSettings.Size,
//                    Offset = (paginationSettings.Index - 1) * paginationSettings.Size
//                },
//                transaction: ConnectionDetails.Transaction)).ToList();
//        }

//        public async Task<User> GetAsync(Guid id)
//        {
//            const string query =
//                @"SELECT
//                    [U].[Id],
//                    [U].[IdentityProviderId],
//                    [U].[FirstName],
//                    [U].[LastName],
//                    [U].[Email],
//                    [U].[IsVerified],
//                    [U].[ConcurrencyToken]
//                  FROM [InventoryTracker].[User] AS [U]
//                  WHERE [U].[Id] = @Id;";

//            return (await ConnectionDetails.Connection.QueryAsync<User>(
//                sql: query,
//                param: new
//                {
//                    Id = id
//                },
//                transaction: ConnectionDetails.Transaction)).SingleOrDefault();
//        }

//        public async Task<int> GetTotalUsersCountAsync()
//        {
//            const string query =
//                @"SELECT COUNT(*) 
//                  FROM [InventoryTracker].[User];";

//            return (await ConnectionDetails.Connection.QueryAsync<int>(
//                sql: query,
//                transaction: ConnectionDetails.Transaction)).Single();
//        }
//    }
//}
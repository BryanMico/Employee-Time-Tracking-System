namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class UserRepository : CrudRepository<Users>, IUserRepository
    {
        public UserRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

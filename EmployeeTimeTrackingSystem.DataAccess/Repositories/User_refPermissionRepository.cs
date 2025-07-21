namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class User_refPermissionRepository : CrudRepository<User_refPermission>, IUser_refPermissionRepository
    {
        public User_refPermissionRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

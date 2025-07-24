namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class UserBranchRepository : CrudRepository<UserBranch>, IUserBranchRepository
    {
        public UserBranchRepository() : base(new MyContext())
        {
        }
    }
}

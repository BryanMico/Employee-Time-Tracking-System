namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class BranchesRepository : CrudRepository<Branches>, IBranchesRepository
    {
        public BranchesRepository() : base(new MyContext())
        {
        }
    }
}

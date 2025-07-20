namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class UserBranchService : BaseService<UserBranch>, IUserBranchService
    {
        private IUserBranchRepository _repository;
        public UserBranchService(IUserBranchRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class BranchesService : BaseService<Branches>, IBranchesService
    {
        private IBranchesRepository _repository;
        public BranchesService(IBranchesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

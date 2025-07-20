namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class EmployeesService : BaseService<Employees>, IEmployeesService
    {
        private IEmployeesRepository _repository;
        public EmployeesService(IEmployeesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

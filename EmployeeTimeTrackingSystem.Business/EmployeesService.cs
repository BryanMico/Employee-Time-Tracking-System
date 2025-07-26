namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using System.Linq;

    public class EmployeesService : BaseService<Employees>, IEmployeesService
    {
        private readonly IEmployeesRepository _repository;
        public EmployeesService(IEmployeesRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int Count()
        {
            return _repository.GetAll().Count();
        }
    }
}

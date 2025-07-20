namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class DepartmentsService : BaseService<Departments>, IDepartmentsService
    {
        private IDepartmentsRepository _repository;
        public DepartmentsService(IDepartmentsRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

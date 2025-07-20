namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class SchedulesService : BaseService<Schedules>, ISchedulesService
    {
        private ISchedulesRepository _repository;
        public SchedulesService(ISchedulesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

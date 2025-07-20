namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class TimeEntriesService : BaseService<TimeEntries>, ITimeEntriesService
    {
        private ITimeEntriesRepository _repository;
        public TimeEntriesService(ITimeEntriesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

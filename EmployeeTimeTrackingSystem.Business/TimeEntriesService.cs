namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using System;
    using System.Linq;

    public class TimeEntriesService : BaseService<TimeEntries>, ITimeEntriesService
    {
        private readonly ITimeEntriesRepository _repository;
        private readonly IEmployeesService _employeesService;

        public TimeEntriesService(ITimeEntriesRepository repository, IEmployeesService employeesService) : base(repository)
        {
            _repository = repository;
            _employeesService = employeesService;
        }

        public int CountPresent(DateTime date)
        {
            return _repository.GetAll()
                .Count(te => te.ClockIn.Date == date);
        }

        public int CountLate(DateTime date)
        {
            var lateThreshold = new TimeSpan(9, 0, 0);
            return _repository.GetAll()
                .Count(te => te.ClockIn.Date == date && te.ClockIn.TimeOfDay > lateThreshold);
        }

        public int CountAbsent(DateTime date)
        {
            var allEmployeeIds = _employeesService.GetAll().Select(e => e.EmployeeID).ToList();
            var presentEmployeeIds = _repository.GetAll()
                .Where(te => te.ClockIn.Date == date)
                .Select(te => te.EmployeeID)
                .Distinct()
                .ToList();

            return allEmployeeIds.Except(presentEmployeeIds).Count();
        }

    }
}

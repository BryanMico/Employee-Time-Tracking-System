namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class TimeEntriesRepository : CrudRepository<TimeEntries>, ITimeEntriesRepository
    {
        public TimeEntriesRepository() : base(new MyContext())
        {
        }
    }
}

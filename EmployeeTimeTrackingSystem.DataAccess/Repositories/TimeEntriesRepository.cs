namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;
    using InvenTree.DataAccess.Repositories;

    public class TimeEntriesRepository : CrudRepository<TimeEntries>, ITimeEntriesRepository
    {
        public TimeEntriesRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

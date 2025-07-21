namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class SchedulesRepository : CrudRepository<Schedules>, ISchedulesRepository
    {
        public SchedulesRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;
    using InvenTree.DataAccess.Repositories;

    public class SchedulesRepository : CrudRepository<Schedules>, ISchedulesRepository
    {
        public SchedulesRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

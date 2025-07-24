namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class SchedulesRepository : CrudRepository<Schedules>, ISchedulesRepository
    {
        public SchedulesRepository() : base(new MyContext())
        {
        }
    }
}

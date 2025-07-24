namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class AuditLogsRepository : CrudRepository<AuditLogs>, IAuditLogsRepository
    {
        public AuditLogsRepository() : base(new MyContext())
        {
        }
    }
}

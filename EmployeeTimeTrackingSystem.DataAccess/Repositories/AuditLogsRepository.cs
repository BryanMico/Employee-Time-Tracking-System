namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;
    using InvenTree.DataAccess.Repositories;

    public class AuditLogsRepository : CrudRepository<AuditLogs>, IAuditLogsRepository
    {
        public AuditLogsRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

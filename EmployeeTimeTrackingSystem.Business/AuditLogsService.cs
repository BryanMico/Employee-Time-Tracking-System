namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class AuditLogsService : BaseService<AuditLogs>, IAuditLogsService
    {
        private IAuditLogsRepository _repository;
        public AuditLogsService(IAuditLogsRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

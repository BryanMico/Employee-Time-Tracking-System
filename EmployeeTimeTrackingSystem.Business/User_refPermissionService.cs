namespace EmployeeTimeTrackingSystem.Business
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class User_refPermissionService : BaseService<User_refPermission>, IUser_refPermissionService
    {
        private IUser_refPermissionRepository _repository;
        public User_refPermissionService(IUser_refPermissionRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

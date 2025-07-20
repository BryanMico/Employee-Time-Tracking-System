
namespace EmployeeTimeTrackingSystem.Business
{

    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

    public class UserService : BaseService<Users>, IUserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
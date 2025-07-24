namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class EmployeesRepository : CrudRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository() : base(new MyContext())
        {
        }
    }
}

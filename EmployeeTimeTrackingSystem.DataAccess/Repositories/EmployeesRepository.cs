namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;
    using InvenTree.DataAccess.Repositories;

    public class EmployeesRepository : CrudRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

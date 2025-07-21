namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;

    public class DepartmentsRepository : CrudRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

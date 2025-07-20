namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
    using EmployeeTimeTrackingSystem.Common.Model;
    using InvenTree.DataAccess.Repositories;

    public class DepartmentsRepository : CrudRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(string connectionString) : base(new MyContext(connectionString))
        {
        }
    }
}

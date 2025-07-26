namespace EmployeeTimeTrackingSystem.Common.Contracts.Repository
{
    using EmployeeTimeTrackingSystem.Common.Contracts.Service;
    using EmployeeTimeTrackingSystem.Common.Model;

    public interface IEmployeesService : IService<Employees>
    {
        int Count();
    }
}

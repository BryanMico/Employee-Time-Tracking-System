namespace EmployeeTimeTrackingSystem.Common.Contracts.Repository
{
    using EmployeeTimeTrackingSystem.Common.Model;
    using EmployeeTimeTrackingSystem.Common.Contracts.Service;
    using System;

    public interface ITimeEntriesService : IService<TimeEntries>
    {
        int CountPresent(DateTime date);
        int CountLate(DateTime date);
        int CountAbsent(DateTime date);
    }
}

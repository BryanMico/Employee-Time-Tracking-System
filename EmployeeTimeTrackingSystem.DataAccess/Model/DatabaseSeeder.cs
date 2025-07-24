using EmployeeTimeTrackingSystem.Common.Contracts.Service;
using EmployeeTimeTrackingSystem.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTimeTrackingSystem.DataAccess
{
    public class DatabaseSeeder: IDatabaseSeeder
    {
        private readonly MyContext _context;

        public DatabaseSeeder(MyContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(new List<Departments>
                {
                    new Departments { DepartmentID = 1, DepartmentName = "IT", IsActive = true },
                    new Departments { DepartmentID = 2, DepartmentName = "HR", IsActive = true },
                    new Departments { DepartmentID = 3, DepartmentName = "Finance", IsActive = true },
                });
                _context.SaveChanges();
            }

            if (!_context.Roles.Any())
            {
                _context.Roles.AddRange(new List<Role>
                {
                    new Role { RoleID = 1, RoleName = "Admin", Description = "System Administrator" },
                    new Role { RoleID = 2, RoleName = "Employee", Description = "Regular Employee" },
                    new Role { RoleID = 3, RoleName = "Manager", Description = "Department Manager" },
                    new Role { RoleID = 4, RoleName = "Supervisor", Description = "Team Supervisor" },
                });
                _context.SaveChanges();
            }

            if (!_context.Branches.Any())
            {
                _context.Branches.AddRange(new List<Branches>
                {
                    new Branches { BranchID = 1, BranchName = "Head Office", IsDisabled = false },
                    new Branches { BranchID = 2, BranchName = "Satellite Office", IsDisabled = false },
                });
                _context.SaveChanges();
            }

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(new List<Employees>
                {
                    new Employees { EmployeeID = 1, FullName = "Admin", DepartmentID = 1, IsActive = true },
                    new Employees { EmployeeID = 2, FullName = "Employee", DepartmentID = 2, IsActive = true },
                    new Employees { EmployeeID = 3, FullName = "Manager", DepartmentID = 3, IsActive = true },
                    new Employees { EmployeeID = 4, FullName = "Supervisor", DepartmentID = 1, IsActive = true },
                });
                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                _context.Users.AddRange(new List<Users>
                {
                    new Users
                    {
                        UserID = 1,
                        UserName = "admin",
                        RealName = "Administrator",
                        Password = "0192023A7BBD73250516F069DF18B500", 
                        IsActive = true,
                        RoleID = 1,
                        EmployeeID = 1
                    },
                    new Users
                    {
                        UserID = 2,
                        UserName = "employee",
                        RealName = "Employee",
                        Password = "0192023A7BBD73250516F069DF18B500",
                        IsActive = true,
                        RoleID = 2,
                        EmployeeID = 2
                    },
                    new Users
                    {
                        UserID = 3,
                        UserName = "manager",
                        RealName = "Manager",
                        Password = "0192023A7BBD73250516F069DF18B500",
                        IsActive = true,
                        RoleID = 3,
                        EmployeeID = 3
                    },
                    new Users
                    {
                        UserID = 4,
                        UserName = "supervisor",
                        RealName = "Supervisor",
                        Password = "0192023A7BBD73250516F069DF18B500",
                        IsActive = true,
                        RoleID = 4,
                        EmployeeID = 4
                    }
                });
                _context.SaveChanges();
            }

            if (!_context.UserBranches.Any())
            {
                _context.UserBranches.AddRange(new List<UserBranch>
                {
                    new UserBranch { UserID = 1, BranchID = 1 },
                    new UserBranch { UserID = 2, BranchID = 2 },
                    new UserBranch { UserID = 3, BranchID = 1 },
                    new UserBranch { UserID = 4, BranchID = 2 },
                });
                _context.SaveChanges();
            }

            if (!_context.Schedules.Any())
            {
                _context.Schedules.AddRange(new List<Schedules>
                {
                    new Schedules
                    {
                        ScheduleID = 1,
                        EmployeeID = 2,
                        ShiftStart = new TimeSpan(8, 0, 0),
                        ShiftEnd = new TimeSpan(17, 0, 0),
                        DayOfWeek = "Monday"
                    },
                    new Schedules
                    {
                        ScheduleID = 2,
                        EmployeeID = 3,
                        ShiftStart = new TimeSpan(9, 0, 0),
                        ShiftEnd = new TimeSpan(18, 0, 0),
                        DayOfWeek = "Monday"
                    },
                    new Schedules
                    {
                        ScheduleID = 3,
                        EmployeeID = 4,
                        ShiftStart = new TimeSpan(8, 30, 0),
                        ShiftEnd = new TimeSpan(17, 30, 0),
                        DayOfWeek = "Monday"
                    }
                });
                _context.SaveChanges();
            }

            if (!_context.TimeEntries.Any())
            {
                _context.TimeEntries.AddRange(new List<TimeEntries>
                {
                    new TimeEntries
                    {
                        EntryID = 1,
                        EmployeeID = 2,
                        ClockIn = DateTime.Today.AddHours(8),
                        ClockOut = DateTime.Today.AddHours(17),
                        HoursWorked = 9,
                        Remarks = "Regular shift"
                    },
                    new TimeEntries
                    {
                        EntryID = 2,
                        EmployeeID = 3,
                        ClockIn = DateTime.Today.AddHours(9),
                        ClockOut = DateTime.Today.AddHours(18),
                        HoursWorked = 9,
                        Remarks = "Late arrival due to meeting"
                    }
                });
                _context.SaveChanges();
            }

            if (!_context.AuditLogs.Any())
            {
                _context.AuditLogs.AddRange(new List<AuditLogs>
                {
                    new AuditLogs
                    {
                        LogID = 1,
                        UserID = 1,
                        Action = "Seeded database",
                        Timestamp = DateTime.Now,
                        Description = "Initial data seeding"
                    },
                    new AuditLogs
                    {
                        LogID = 2,
                        UserID = 2,
                        Action = "Clocked In",
                        Timestamp = DateTime.Today.AddHours(8),
                        Description = "Started work shift"
                    }
                });
                _context.SaveChanges();
            }
        }
    }
}

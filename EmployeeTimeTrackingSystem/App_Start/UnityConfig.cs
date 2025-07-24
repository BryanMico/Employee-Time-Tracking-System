using EmployeeTimeTrackingSystem.Business;
using EmployeeTimeTrackingSystem.Common.Contracts.Repository;
using EmployeeTimeTrackingSystem.Common.Contracts.Service;
using EmployeeTimeTrackingSystem.DataAccess;
using EmployeeTimeTrackingSystem.DataAccess.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace EmployeeTimeTrackingSystem
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			container.RegisterType<IUserRepository, UserRepository>();
			container.RegisterType<IEmployeesRepository, EmployeesRepository>();
			container.RegisterType<IBranchesRepository, BranchesRepository>();
			container.RegisterType<IUserBranchRepository, UserBranchRepository>();
			container.RegisterType<IUser_refPermissionRepository, User_refPermissionRepository>();
			container.RegisterType<IDepartmentsRepository, DepartmentsRepository>();
			container.RegisterType<ISchedulesRepository, SchedulesRepository>();
			container.RegisterType<ITimeEntriesRepository, TimeEntriesRepository>();
			container.RegisterType<IAuditLogsRepository, AuditLogsRepository>();



			container.RegisterType<IUserService, UserService>();
			container.RegisterType<IEmployeesService, EmployeesService>();
			container.RegisterType<IBranchesService, BranchesService>();
			container.RegisterType<IUserBranchService, UserBranchService>();
			container.RegisterType<IUser_refPermissionService, User_refPermissionService>();
			container.RegisterType<IDepartmentsService, DepartmentsService>();
			container.RegisterType<ISchedulesService, SchedulesService>();
			container.RegisterType<ITimeEntriesService, TimeEntriesService>();
			container.RegisterType<IAuditLogsService, AuditLogsService>();
			container.RegisterType<IDatabaseSeeder, DatabaseSeeder>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}
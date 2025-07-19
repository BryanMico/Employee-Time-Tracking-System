using EmployeeTimeTrackingSystem.Common.Model;
using System.Data.Entity;

namespace EmployeeTimeTrackingSystem.DataAccess
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EmployeeDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("Users", "dbo").HasKey(u => u.UserID);
            modelBuilder.Entity<Employees>().ToTable("Employees", "dbo").HasKey(e => e.EmployeeID);
            modelBuilder.Entity<TimeEntries>().ToTable("TimeEntries", "dbo").HasKey(t => t.EntryID);
            modelBuilder.Entity<Departments>().ToTable("Departments", "dbo").HasKey(d => d.DepartmentID);
            modelBuilder.Entity<Schedules>().ToTable("Schedules", "dbo").HasKey(s => s.ScheduleID);
            modelBuilder.Entity<AuditLogs>().ToTable("AuditLogs", "dbo").HasKey(a => a.LogID);
        }

    }
}

using EmployeeTimeTrackingSystem.Common.Model;
using System.Data.Entity;

namespace EmployeeTimeTrackingSystem.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<TimeEntries> TimeEntries { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<User_refPermission> User_refPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("Users", "dbo").HasKey(u => u.UserID);
            modelBuilder.Entity<Users>().HasRequired(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Users>().HasOptional(u => u.Employee).WithMany().HasForeignKey(u => u.EmployeeID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>().ToTable("Employees", "dbo").HasKey(e => e.EmployeeID);
            modelBuilder.Entity<Employees>().HasRequired(e => e.Department).WithMany().HasForeignKey(e => e.DepartmentID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Departments>().ToTable("Departments", "dbo").HasKey(d => d.DepartmentID);

            modelBuilder.Entity<TimeEntries>().ToTable("TimeEntries", "dbo").HasKey(t => t.EntryID);
            modelBuilder.Entity<TimeEntries>().HasRequired(t => t.Employee).WithMany().HasForeignKey(t => t.EmployeeID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedules>().ToTable("Schedules", "dbo").HasKey(s => s.ScheduleID);
            modelBuilder.Entity<Schedules>().HasRequired(s => s.Employee).WithMany().HasForeignKey(s => s.EmployeeID).WillCascadeOnDelete(false);

            modelBuilder.Entity<AuditLogs>().ToTable("AuditLogs", "dbo").HasKey(a => a.LogID);
            modelBuilder.Entity<AuditLogs>().HasRequired(a => a.User).WithMany().HasForeignKey(a => a.UserID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>().ToTable("Roles", "dbo").HasKey(r => r.RoleID);

            modelBuilder.Entity<UserBranch>().ToTable("UserBranches", "dbo").HasKey(ub => new { ub.UserID, ub.BranchID });
            modelBuilder.Entity<UserBranch>().HasRequired(ub => ub.User).WithMany().HasForeignKey(ub => ub.UserID).WillCascadeOnDelete(false);
            modelBuilder.Entity<UserBranch>().HasRequired(ub => ub.Branch).WithMany().HasForeignKey(ub => ub.BranchID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Branches>().ToTable("Branches", "dbo").HasKey(b => b.BranchID);

            modelBuilder.Entity<User_refPermission>().ToTable("User_refPermissions", "dbo").HasKey(p => p.PermissionID);
        }
    }
}

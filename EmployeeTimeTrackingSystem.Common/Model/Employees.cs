using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public bool? IsActive { get; set; }

        public virtual Departments Department { get; set; }
    }
}

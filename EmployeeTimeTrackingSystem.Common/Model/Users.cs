using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(100)]
        public string RealName { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        [Required]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public int? EmployeeID { get; set; }
        public virtual Employees Employee { get; set; }
    }
}

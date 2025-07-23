using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTrackingSystem.Common.Model
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Users> Users { get; set; }

        public Role()
        {
            Users = new HashSet<Users>();
        }
    }
}

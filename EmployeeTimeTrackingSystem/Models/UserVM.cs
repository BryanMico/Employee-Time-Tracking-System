using EmployeeTimeTrackingSystem.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTimeTrackingSystem.Models
{
    public class UserVM
    {
        public int UserID { get; set; }

        [Required]
        public string RealName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserPermissionVM
    {
        public int UserID { get; set; }
        public List<User_refPermission> PermissionList { get; set; }
        public List<Branches> Branch { get; set; }
        public List<UserBranch> UserBranch { get; set; }
    }
}
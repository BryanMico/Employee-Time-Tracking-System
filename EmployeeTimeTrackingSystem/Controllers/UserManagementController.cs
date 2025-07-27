using System.Web.Mvc;
using EmployeeTimeTrackingSystem.Models;
using System.Text;
using EmployeeTimeTrackingSystem.Business;
using System.Linq;
using EmployeeTimeTrackingSystem.Helpers;
using EmployeeTimeTrackingSystem.Common.Contracts.Repository;

namespace EmployeeTimeTrackingSystem.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Incorrect Username/Password" });
                }
                ModelState.AddModelError("", "Incorrect Username/Password");
                return View(user);
            }

            var hashedPass = Md5Generator(user.Password);
            var userlog = _userService.Get(a => a.UserName == user.UserName && a.Password == hashedPass).FirstOrDefault();

            if (userlog != null)
            {
                Session["RealName"] = userlog.RealName;
                Session["RoleName"] = userlog.Role?.RoleName ?? "User";

                UserAuthentication.SetAuthentication(userlog);

                if (Request.IsAjaxRequest())
                {
                    string redirectUrl = (userlog.RoleID == 1) ? Url.Action("Index", "Branch") : Url.Action("Index", "Dashboard");
                    return Json(new { success = true, redirect = redirectUrl });
                }

                if (userlog.RoleID == 1)
                    return RedirectToAction("Index", "Branch");
                else
                    return RedirectToAction("Index", "Dashboard");
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = false, message = "The user name or password you’ve entered is incorrect" });
            }

            ModelState.AddModelError("", "The user name or password you’ve entered is incorrect");
            return View(user);
        }

        public string Md5Generator(string password)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(password);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2"));
                return sb.ToString();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("UserLogin");
        }
    }
}

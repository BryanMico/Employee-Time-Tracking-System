namespace EmployeeTimeTrackingSystem.Attributes
{
    using EmployeeTimeTrackingSystem.Helpers;
    using System.Web.Mvc;

    public class InPrivateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if (UserAuthentication.UserId == 0)
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { sessionexpired = true, message = "Session expired" }
                    };
                }
                else
                {
                    if (UserAuthentication.UserId == 0)
                    {
                        filterContext.HttpContext.Response.Redirect("~/UserManagement/UserLogin");
                    }

                }
    
            }


        }
    }
}
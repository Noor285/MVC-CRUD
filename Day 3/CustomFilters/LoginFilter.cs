using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day_3.CustomFilters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
                context.Result = new ContentResult() { Content = "You Must Login" };
           // base.OnActionExecuting(context);
        }
    }
}

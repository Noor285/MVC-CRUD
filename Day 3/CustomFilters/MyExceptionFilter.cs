using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day_3.CustomFilters
{
    public class MyExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName = "MyError" }; // new ContentResult() { Content = "plz try again" };
            }
            base.OnActionExecuted(context);
        }
    }
}
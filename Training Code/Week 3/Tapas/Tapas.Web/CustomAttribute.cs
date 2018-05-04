using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tapas.Web
{
    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("On Result Executed");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine("On Result Executing");
        }
    }
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("On Action Executed");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("On Action Executing");
        }
    }
    public class CustomAuthorisationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("Checking if user is authorized");
        }
    }
    public class CustomErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Debug.WriteLine("We should log the errors using Nlog");
        }
    }
}
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterDemo.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action is starting...");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action finished...");
        }
    }
}
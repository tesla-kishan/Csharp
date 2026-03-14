using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilterDemo.Filters
{
    public class CustomAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Request.Headers["user"];

            if (user != "admin")
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
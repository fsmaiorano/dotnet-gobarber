using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.Equals("/signin"))
            {
                    
            }
            

            //Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
            //if (context.HttpContext.Request.Headers.ContainsKey("token"))
            //{
            //    var token = context.HttpContext.Request.Headers["token"][0];
            //}
            //else
            //{
            //    var x = 1;
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}

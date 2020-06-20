using GoBarber.Web.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();

            var storedUser =  cache.Get(CacheConstants.User);

            if (!context.HttpContext.Request.Path.Equals("/signin") && storedUser == null)
            {
                context.RouteData.Values["controller"] = "Authentication";
                context.RouteData.Values["action"] = "Index";
            }

            base.OnActionExecuting(context);
        }
    }
}

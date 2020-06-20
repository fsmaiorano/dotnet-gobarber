using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoBarber.Web.Models;
using Microsoft.Extensions.Caching.Memory;
using GoBarber.Web.Helpers;
using GoBarber.Web.Filters;

namespace GoBarber.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _cache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        [AuthenticationFilter]
        public IActionResult Index()
        {
            //var storedUser = _cache.Get(CacheConstants.User);

            //if (storedUser == null)
            //    return Redirect("/signin");
            //else
            //    return Redirect("/dashboard");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

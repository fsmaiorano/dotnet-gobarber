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
using GoBarber.Web.ViewModels.User;
using GoBarber.DTO.User;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authorization;
using GoBarber.Web.Services;

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
      var user = (UserDTO)_cache.Get(CacheConstants.User);

      if (user == null)
      {
        return RedirectToAction("index", "authentication");
      }

      var vm = _cache.Get(CacheConstants.UserViewModel);

      return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

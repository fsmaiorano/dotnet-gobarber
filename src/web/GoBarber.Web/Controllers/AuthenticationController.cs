using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GoBarber.Web.Helpers;
using GoBarber.Web.Models;
using GoBarber.Web.Models.SignIn;
using GoBarber.Web.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GoBarber.Web.Controllers.Authentication
{
    [Route("signin")]
    public class AuthenticationController : Controller
    {
        private IMemoryCache _cache;

        public AuthenticationController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthenticationModelInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var signInResponse = await SignInService.DoLogin(input);

            if (signInResponse.Success)
            {
                _cache.Set(CacheConstants.User, signInResponse.User);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

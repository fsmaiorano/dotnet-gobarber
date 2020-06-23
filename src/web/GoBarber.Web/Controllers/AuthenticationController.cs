﻿using GoBarber.DTO.Authentication;
using GoBarber.Web.Helpers;
using GoBarber.Web.services;
using GoBarber.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace GoBarber.Web.Controllers.Authentication
{
    [Route("signin")]
    [AllowAnonymous]
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
        public async Task<IActionResult> PostAsync([FromBody] AuthenticationInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var signInResponse = await UserService.Authentication(input);

            if (signInResponse.Success)
            {
                var vm = new UserViewModel(signInResponse.User.Name,
                                signInResponse.User.Email,
                                signInResponse.User.Avatar,
                                signInResponse.User.Role,
                                signInResponse.User.Token);

                _cache.Set(CacheConstants.UserViewModel, vm);
                _cache.Set(CacheConstants.User, signInResponse.User);
                return Ok(signInResponse);
            }
            else
            {
                return BadRequest();
            }
        }
       
        public IActionResult LogOut()
        {
            _cache.Remove(CacheConstants.UserViewModel);
            _cache.Remove(CacheConstants.User);
            return RedirectToAction("index", "authentication");
        }
    }
}

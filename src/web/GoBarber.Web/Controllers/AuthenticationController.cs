using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GoBarber.Web.Models;
using GoBarber.Web.Models.SignIn;
using GoBarber.Web.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBarber.Web.Controllers.Authentication
{
    [Route("signin")]
    public class AuthenticationController : Controller
    {
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
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

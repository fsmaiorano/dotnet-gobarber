using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GoBarber.Application.Config;
using GoBarber.Application.Models;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GoBarber.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IOptions<AppSettings> appSettings, IAuthenticationService authenticationService)
        {
            _appSettings = appSettings;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public AuthenticationModelResult Login([FromBody] AuthenticationModelInput input)
        {
            try
            {
                var user = _authenticationService.SignIn(input.Email, input.Password);

                if (user != null)
                {
                    return new AuthenticationModelResult { UserId = user.Id, Token = user.Token, Email = user.Email };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

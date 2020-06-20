﻿using System;
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GoBarber.Application.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IOptions<AppSettings> appSettings, IAuthenticationService authenticationService)
        {
            _appSettings = appSettings;
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public AuthenticationModelResult Login(AuthenticationModelInput input)
        {
            try
            {
                var user = _authenticationService.SignIn(input.Email, input.Password);

                if (user != null)
                {
                    return new AuthenticationModelResult { Token = user.Token, User = user , Success = true };
                }
                else
                {
                    return new AuthenticationModelResult { Success = false };
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"AuthenticationController/Login - {ex.Message}");
                return new AuthenticationModelResult { Success = false };
            }
        }
    }
}

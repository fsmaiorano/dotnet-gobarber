using AutoMapper;
using GoBarber.Application.Config;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Authentication;
using GoBarber.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace GoBarber.Application.Controllers.Authentication
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IOptions<AppSettings> appSettings, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _appSettings = appSettings;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public AuthenticationResult Login(AuthenticationInput input)
        {
            var result = new AuthenticationResult();
            try
            {
                var authResponse = _authenticationService.SignIn(input.Email, input.Password);

                if (authResponse.Success)
                {
                    result.Success = true;
                    result.User = authResponse.User;
                }
                else
                {
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"AuthenticationController/Login - {ex.Message}");
                result.Success = false;
            }

            return result;
        }
    }
}

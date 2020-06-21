using GoBarber.Application.Config;
using GoBarber.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using static GoBarber.DTO.Authentication.AuthenticationDTO;

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
        [AllowAnonymous]
        public AuthenticationResult Login(AuthenticationInput input)
        {
            try
            {
                var user = _authenticationService.SignIn(input.Email, input.Password);

                if (user != null)
                {
                    return new AuthenticationResult { Token = user.Token, Name = user.Name, Email = user.Email, Avatar = user.Avatar, Success = true };
                }
                else
                {
                    return new AuthenticationResult { Success = false };
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"AuthenticationController/Login - {ex.Message}");
                return new AuthenticationResult { Success = false };
            }
        }
    }
}

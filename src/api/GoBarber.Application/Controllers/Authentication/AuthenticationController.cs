using AutoMapper;
using GoBarber.Application.Config;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Authentication;
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
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IOptions<AppSettings> appSettings, IAuthenticationService authenticationService, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _appSettings = appSettings;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public AuthenticationResult Login(AuthenticationInput input)
        {
            try
            {
                var user = _authenticationService.SignIn(input.Email, input.Password);

                var userDTO = _mapper.Map<UserEntity, AuthenticationDTO>(user);

                if (user != null)
                {
                    return new AuthenticationResult { User = userDTO, Success = true };
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

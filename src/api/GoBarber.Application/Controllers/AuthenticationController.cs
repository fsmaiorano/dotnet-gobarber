using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GoBarber.Application.Config;
using GoBarber.Domain.Entities;
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
        public AuthenticationController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        [HttpGet]
        public IActionResult Login()
        {
           //validar se o usu'ario existe,
           //se exister passar para o gerartokenjwt
           //o token levar'a os dados que eu quiser apra fora
            var tokenString = GerarTokenJWT();
            return null;
           
        }
        private string GerarTokenJWT()
        {
            var issuer = _appSettings.Value.JWTIssuer;
            var audience = _appSettings.Value.JWTAudience;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.JWTKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("UserId", "1"),
            };

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, claims,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private bool ValidarUsuario(UserEntity loginDetalhes)
        {
            return true;
        }
    }
}

﻿using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using GoBarber.CrossCutting.Configuration;

namespace GoBarber.Service.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IRepository<UserTokenEntity> _userTokenRepository;
        private IUserRepository<UserEntity> _userRepository;
        private IAuthenticationRepository<UserTokenEntity> _authenticationRepository;
        public AuthenticationService(IRepository<UserTokenEntity> userTokenRepository, IUserRepository<UserEntity> userRepository, IAuthenticationRepository<UserTokenEntity> authenticationRepository)
        {
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _authenticationRepository = authenticationRepository;
        }



        public UserEntity SignIn(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user != null)
            {
                var token = GenerateToken(user);
                user.Token = token;

                var userToken = new UserTokenEntity
                {
                    UserId = user.Id,
                    Token = user.Token,
                };

                var storedToken = GetByUserId(user.Id);

                if(storedToken != null) {
                    storedToken.Token = token;
                    _userTokenRepository.Update(storedToken);
                }
                else {
                    _userTokenRepository.Insert(userToken);
                }
         
            }
            else
            {
                user = null;
            }

            return user;
        }
        public UserTokenEntity GetByUserId(int userId)
        {
            return _authenticationRepository.GetByUserId(userId);
        }

        private string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CrossSettings.JwtSecret));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.Now.AddHours(500),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

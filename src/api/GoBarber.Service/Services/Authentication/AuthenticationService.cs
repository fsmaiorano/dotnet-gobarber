using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using GoBarber.CrossCutting.Configuration;
using GoBarber.Data.UnitOfWork;
using AutoMapper;
using GoBarber.DTO.Authentication;
using GoBarber.DTO.User;

namespace GoBarber.Service.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public AuthenticationResult SignIn(string email, string password)
        {
            var result = new AuthenticationResult();

            try
            {
                var user = _unitOfWork.UserRepository.GetByEmail(email);

                if (user != null)
                {
                    var token = TokenService.GenerateToken(user);
                    user.Token = token;

                    var userToken = new UserTokenEntity
                    {
                        UserId = user.Id,
                        Token = user.Token,
                    };

                    var userTokenEntity = _unitOfWork.AuthenticationRepository.GetByUserId(user.Id);

                    if (userTokenEntity != null)
                    {
                        userTokenEntity.Token = token;

                        _unitOfWork.AuthenticationRepository.Update(userTokenEntity);
                    }
                    else
                    {
                        _unitOfWork.AuthenticationRepository.Insert(userToken);
                    }

                    _unitOfWork.Commit();

                    result.User = _mapper.Map<UserEntity, UserDTO>(user);
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                }

            }
            catch (Exception)
            {
                result.Success = false;
                
            }

            return result;
        }

        public AuthenticationResult GetByUserId(int userId)
        {
            var result = new AuthenticationResult();

            try
            {
                var storedUserToken = _unitOfWork.AuthenticationRepository.GetByUserId(userId);

                if(storedUserToken == null) {
                    result.Success = false;
                }
                else {
                    result.User = _mapper.Map<UserEntity, UserDTO>(storedUserToken.User);
                    result.User.Token = storedUserToken.Token;
                }

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }
    }
}

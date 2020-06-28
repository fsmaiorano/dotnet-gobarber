using AutoMapper;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.User;
using GoBarber.Service.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoBarber.Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserResult Insert(UserInput user)
        {
            var result = new UserResult();

            try
            {
                var userEntity = _mapper.Map<UserInput, UserEntity>(user);
                var createdUser = _unitOfWork.UserRepository.Insert(userEntity);

                _unitOfWork.Commit();

                createdUser.Token = TokenService.GenerateToken(createdUser);

                var userDTO = _mapper.Map<UserEntity, UserDTO>(createdUser);

                result.User = userDTO;
                result.Success = true;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }

        public UserResult GetById(int id)
        {
            var result = new UserResult();

            try
            {
                var user = _unitOfWork.UserRepository.GetById(id);

                if (user != null)
                {
                    var userDTO = _mapper.Map<UserEntity, UserDTO>(user);

                    result.User = userDTO;
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

        public UserResult Get()
        {
            var result = new UserResult();

            try
            {
                var users = _unitOfWork.UserRepository.Get();
                var userDTO = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserDTO>>(users);

                result.Users = userDTO;
                result.Success = true;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public UserResult Update(UserInput user)
        {
            var result = new UserResult();

            try
            {
                var userEntity = _mapper.Map<UserInput, UserEntity>(user);
                var updatedUser = _unitOfWork.UserRepository.Update(userEntity);

                _unitOfWork.Commit();

                var userDTO = _mapper.Map<UserEntity, UserDTO>(updatedUser);

                result.User = userDTO;
                result.Success = true;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                result.Success = false;
            }

            return result;
        }
        public UserResult Delete(int id)
        {
            var result = new UserResult();

            try
            {
                var isDeleted = _unitOfWork.UserRepository.Delete(id);

                if (isDeleted)
                    result.Success = true;
                else
                    result.Success = false;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public UserResult GetByEmail(string email)
        {
            var result = new UserResult();

            try
            {
                var user = _unitOfWork.UserRepository.GetByEmail(email);

                if (user != null)
                {
                    var userDTO = _mapper.Map<UserEntity, UserDTO>(user);

                    result.User = userDTO;
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
    }
}

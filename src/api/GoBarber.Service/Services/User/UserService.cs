﻿using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GoBarber.Service.Services.User
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            return _unitOfWork.UserRepository.Delete(id);
        }

        public UserEntity Insert(UserEntity user)
        {
            try
            {
                var x = _unitOfWork.UserRepository.GetByEmail("Kelvin0@yahoo.com");
                var createdUser = _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Commit();
                return createdUser;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }

        public UserEntity GetById(int id)
        {
            return _unitOfWork.UserRepository.Select(id);
        }

        public IEnumerable<UserEntity> SelectAll()
        {
            return _unitOfWork.UserRepository.Select();
        }

        public UserEntity Update(UserEntity user)
        {
            try
            {
                var updatedUser = _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Commit();
                return updatedUser;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }

        public UserEntity GetByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetByEmail(email);
        }
    }
}

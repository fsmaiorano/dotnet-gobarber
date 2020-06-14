using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GoBarber.Service.Services.User
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private IUserRepository<UserEntity> _userRepository;
        private IUnitOfWork _unitOfWork;
        public UserService(IRepository<UserEntity> repository, IUserRepository<UserEntity> userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public UserEntity Insert(UserEntity user)
        {
            try
            {
                var createdUser = _repository.Insert(user);
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
            return _repository.Select(id);
        }

        public IEnumerable<UserEntity> SelectAll()
        {
            return _repository.Select();
        }

        public UserEntity Update(UserEntity user)
        {
            return _repository.Update(user);
        }

        public UserEntity GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }
    }
}

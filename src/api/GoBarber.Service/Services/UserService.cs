using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GoBarber.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public UserEntity Insert(UserEntity user)
        {
            return _repository.Insert(user);
        }

        public UserEntity Select(int id)
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

        public bool Teste()
        {
            throw new NotImplementedException();
        }
    }
}

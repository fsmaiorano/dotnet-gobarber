﻿using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Int32 id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Int32 id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}

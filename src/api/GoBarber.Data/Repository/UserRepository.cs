﻿using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GoBarber.Data.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<UserEntity>();
        }

        public bool DeleteByEmail(string email)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Email.Equals(email));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                //_context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        UserEntity IUserRepository.GetByEmail(string email)
        {
            try
            {
                return _dataset.SingleOrDefault(p => p.Email.Equals(email));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

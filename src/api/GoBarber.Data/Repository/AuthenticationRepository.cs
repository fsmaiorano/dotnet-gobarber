using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBarber.Data.Repository
{
    public class AuthenticationRepository<T> : IAuthenticationRepository<T> where T : UserTokenEntity
    {

        protected readonly MyContext _context;
        private DbSet<UserTokenEntity> _dataset;

        public AuthenticationRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<UserTokenEntity>();
        }
        public T GetByUserId(int userId)
        {
            return (T)_dataset.SingleOrDefault(x => x.UserId.Equals(userId));
        }
    }
}

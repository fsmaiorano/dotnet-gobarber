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
    public class AuthenticationRepository : Repository<UserTokenEntity>, IAuthenticationRepository
    {
        private readonly DbSet<UserTokenEntity> _dataset;

        public AuthenticationRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<UserTokenEntity>();
        }

        UserTokenEntity IAuthenticationRepository.GetByUserId(int userId)
        {
            return _dataset.SingleOrDefault(x => x.UserId.Equals(userId));
        }
    }
}

using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Data.Repository
{
    public class UserRepository : IUserRepository<UserEntity>
    {
        public bool teste()
        {
            throw new NotImplementedException();
        }
    }
}

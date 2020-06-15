using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByEmail(string email);
        bool DeleteByEmail(string email);
    }
}

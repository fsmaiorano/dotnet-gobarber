using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IUserService
    {
        UserEntity GetById(Int32 id);
        UserEntity GetByEmail(string email);

        IEnumerable<UserEntity> SelectAll();

        UserEntity Insert(UserEntity user);

        UserEntity Update(UserEntity user);

        bool Delete(Int32 id);
    }
}


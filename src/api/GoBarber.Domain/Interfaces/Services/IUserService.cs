using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IUserService
    {
        UserEntity Select(Int32 id);
        UserEntity Select(string email);

        IEnumerable<UserEntity> SelectAll();

        UserEntity Insert(UserEntity user);

        UserEntity Update(UserEntity user);

        bool Delete(Int32 id);
        bool Delete(string email);
    }
}


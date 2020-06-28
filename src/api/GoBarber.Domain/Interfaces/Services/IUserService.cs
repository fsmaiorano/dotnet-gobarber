using GoBarber.Domain.Entities;
using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IUserService
    {
        UserResult GetById(Int32 id);
        UserResult GetByEmail(string email);

        UserResult Get();

        UserResult Insert(UserInput user);

        UserResult Update(UserInput user);

        UserResult Delete(int id);
    }
}


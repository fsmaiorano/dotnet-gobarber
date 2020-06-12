using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        UserEntity SignIn(string email, string password);
        UserTokenEntity GetByUserId(int userId);
    }
}

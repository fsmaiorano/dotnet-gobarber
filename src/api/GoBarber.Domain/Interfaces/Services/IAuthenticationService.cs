using GoBarber.Domain.Entities;
using GoBarber.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResult SignIn(string email, string password);
        AuthenticationResult GetByUserId(int userId);
    }
}

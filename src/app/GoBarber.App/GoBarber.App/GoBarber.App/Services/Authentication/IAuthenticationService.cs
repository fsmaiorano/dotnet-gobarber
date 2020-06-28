using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.App.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyRegistration();
        Task Authenticate();
    }
}

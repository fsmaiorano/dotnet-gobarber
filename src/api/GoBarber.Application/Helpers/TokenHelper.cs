using GoBarber.Service.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Application.Helpers
{
    public static class TokenHelper
    {
        public static string GetUserIdByToken(string token)
        {
            try
            {
                var tokenArray = token.Split(' ');
                return TokenService.ReadToken(tokenArray[1]);
            }
            catch (Exception)
            {
                return "";    
            }
        }
    }
}

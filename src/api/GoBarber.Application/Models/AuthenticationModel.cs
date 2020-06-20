using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Application.Models
{
    public class AuthenticationModelInput
    {
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string Token { get; set; }
    }

    public class AuthenticationModelResult: GenericResult
    {
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GoBarber.Web.Models.User;

namespace GoBarber.Web.Models.SignIn
{
    public class AuthenticationModelInput
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class AuthenticationModelResult : GenericResult
    {
        public string Token { get; set; }
        public User.User User { get; set; }
    }
}

using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoBarber.DTO.Authentication
{
    public class AuthenticationDTO
    {
        public class AuthenticationInput
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

        public class AuthenticationResult : GenericResult
        {
            public string Token { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Avatar { get; set; }
            public string Role { get; set; }
        }
    }
}

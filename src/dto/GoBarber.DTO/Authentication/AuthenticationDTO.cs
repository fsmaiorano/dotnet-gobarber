using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoBarber.DTO.Authentication
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
        public UserDTO User { get; set; }
    }
}

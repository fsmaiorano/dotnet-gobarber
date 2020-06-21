using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoBarber.DTO.User
{
    public class UserInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }

    public class UserResult : GenericResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }
}

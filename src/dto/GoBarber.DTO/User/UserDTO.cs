using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoBarber.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }

    public class UserInput
    {
        public int Id { get; set; }
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
        public UserDTO User { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
    }
}

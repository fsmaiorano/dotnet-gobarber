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
    }
}

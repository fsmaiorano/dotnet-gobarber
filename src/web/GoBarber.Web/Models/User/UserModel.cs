using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Models.User
{
    public class UserModelInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }

    public class UserModelResult : GenericResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.ViewModels.User
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public UserViewModel(string name, string email, string avatar, string role, string token)
        {
            this.Name = name;
            this.Email = email;
            this.Avatar = avatar;
            this.Role = role;
            this.Token = token;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Application.Models
{
    public class AuthenticationModel
    {
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
    }
}

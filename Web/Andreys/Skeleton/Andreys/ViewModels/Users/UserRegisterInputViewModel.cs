﻿using System.ComponentModel.DataAnnotations;

namespace Andreys.ViewModels.Users
{
    public class UserRegisterInputViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
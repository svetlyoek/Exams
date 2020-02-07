using Panda.App.ViewModels.Users;
using Panda.Models;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Panda.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel inputModel)
        {
            User user = this.userService.GetUserByCredentials(inputModel.Username, this.HashPassword(inputModel.Password));

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = this.HashPassword(inputModel.Password)
            };

            this.userService.CreateUser(user);

            return this.Redirect("/Users/Login");
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}

using Andreys.Services;
using Andreys.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserCreateInputViewModel input)
        {
            var user = this.usersService.GetUserByCeredentials(input.Username, input.Password);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterInputViewModel input)
        {

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                return this.Error("Username must be between 4 and 10 characters!");
            }
            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long!");
            }
            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email is required!");
            }
            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should match!");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}

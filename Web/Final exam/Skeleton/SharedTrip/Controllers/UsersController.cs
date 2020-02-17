using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
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
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginInputViewModel inputModel)
        {
            var userId = this.usersService.GetUserById(inputModel.Username, inputModel.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/");

        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserCreateInputViewModel inputModel)
        {

            if (inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.View();
            }
            if (string.IsNullOrWhiteSpace(inputModel.Username))
            {
                return this.View();
            }
            if (string.IsNullOrWhiteSpace(inputModel.Email))
            {
                return this.View();
            }
            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.View();
            }
            if (string.IsNullOrWhiteSpace(inputModel.Password))
            {
                return this.View();
            }
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.View();
            }

            this.usersService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");

        }

        public HttpResponse Logout()
        {
            if (this.IsUserLoggedIn())
            {
                SignOut();
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }
    }
}

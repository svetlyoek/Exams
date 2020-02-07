using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.Users
{
    public class UserLoginInputModel
    {
        private const string UsernameErrorMessage = "Username must be between 5 and 20 characters!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}

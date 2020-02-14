using Andreys.Models;

namespace Andreys.Services
{
    public interface IUsersService
    {
        User GetUserByCeredentials(string username, string password);

        void Create(string username, string email, string password);
    }
}

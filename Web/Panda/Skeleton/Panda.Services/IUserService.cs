using Panda.Models;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByCredentials(string username, string password);

        IEnumerable<string> GetAllRecipientsByName();
    }
}

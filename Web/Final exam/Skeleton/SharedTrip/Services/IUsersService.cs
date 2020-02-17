using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IUsersService
    {
        string GetUserById(string username, string password);

        void CreateUser(string username, string email, string password);
    }
}

using Panda.Data;
using Panda.Models;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class UserService : IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }

        public User CreateUser(User user)
        {
            var userFromDb = this.context.Users.Where(u => u.Username == user.Username || u.Email == user.Email)
                .FirstOrDefault();

            if (userFromDb == null)
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
            }

            return user;
        }

        public IEnumerable<string> GetAllRecipientsByName()
        {
            return this.context.Users.Select(u => u.Username).ToList();
        }

        public User GetUserByCredentials(string username, string password)
        {
            return this.context.Users.Where(u => u.Username == username && u.Password == password)
                  .FirstOrDefault();
        }


    }
}

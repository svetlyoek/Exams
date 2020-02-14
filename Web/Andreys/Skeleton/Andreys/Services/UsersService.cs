using Andreys.Data;
using Andreys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Andreys.Services
{
    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext context;

        public UsersService(AndreysDbContext context)
        {
            this.context = context;
        }

        public void Create(string username, string email, string password)
        {
            var hasPassword = this.Hash(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = hasPassword
            };

            this.context.Users.Add(user);

            this.context.SaveChanges();
        }

        public User GetUserByCeredentials(string username, string password)
        {
            string hasPassword = this.Hash(password);

            var user = this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == hasPassword);

            if (user == null)
            {
                return null;
            }

            return user;
        }


        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}

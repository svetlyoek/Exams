using SharedTrip.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext context;

        public UsersService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.context.Users.Add(user);

            this.context.SaveChanges();
        }

        public string GetUserById(string username, string password)
        {
            var hashPassword = this.Hash(password);

            var user = this.context.Users.
                FirstOrDefault(u => u.Username == username
                && u.Password == hashPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
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

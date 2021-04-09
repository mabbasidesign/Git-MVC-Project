using Git.Data;
using Git.Models;
using Git.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class UsersService : IUserServices
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(RegisterInputModel inputModel)
        {
            var user = new User
            {
                Email = inputModel.Email,
                Username = inputModel.Username,
                Password = inputModel.Password
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public bool IsEmailAvailable(string email) =>
            !this.db.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username) =>
            !this.db.Users.Any(x => x.Username == username);

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public string GetUserId(LoginInputViewModel inputViewModel)
        {
            var userId = db.Users
                .Where(x => x.Username == inputViewModel.Username && x.Password == ComputeHash(inputViewModel.Password))
                .Select(y => y.Id)
                .FirstOrDefault();

            return userId;
        }

    }
}

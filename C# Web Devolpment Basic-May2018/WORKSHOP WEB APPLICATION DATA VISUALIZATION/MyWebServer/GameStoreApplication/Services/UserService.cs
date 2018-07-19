namespace MyWebServer.GameStoreApplication.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using MyWebServer.Common;
    using System.Linq;

    public class UserService : IUserService
    {
        public bool Create(string email, string name, string password)
        {
            using (var context = new GameStoreDbContext())
            {
                if (context.Users.Any(x => x.Email == email))
                {
                    return false;
                }

                var isAdmin = !context.Users.Any();

                var user = new User()
                {
                    Name = name,
                    Email = email,
                    IsAdmin = isAdmin,
                    PasswordHash = PasswordUtilities.ComputeHash(password)
                };

                var a = user.PasswordHash.Length;
                context.Add(user);
                context.SaveChanges();
            }

            return true;
        }

        public bool Find(string email, string password)
        {
            var passHash = PasswordUtilities.ComputeHash(password);

            using (var db = new GameStoreDbContext())
            {
                return db.Users.Any(x => x.Email == email && x.PasswordHash == passHash);
            }
        }

        public bool IsAdmin(string email)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Users.Any(x => x.IsAdmin && x.Email == email);
            }
        }
    }
}

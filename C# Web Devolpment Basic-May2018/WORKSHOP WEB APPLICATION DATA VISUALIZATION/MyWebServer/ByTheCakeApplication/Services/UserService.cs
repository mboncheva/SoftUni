namespace MyWebServer.ByTheCakeApplication.Services
{
    using Data;
    using Data.Models;
    using MyWebServer.Common;
    using System;
    using System.Linq;
    using ViewModels.Account;

    public class UserService : IUserService
    {
        public bool Create(string name, string username, string password)
        {
            using (var db = new ByTheCakeDbContext())
            {
                if (db.Users.Any(u => u.UserName == username))
                {
                    return false;
                }

                var user = new User
                {
                    Name=name,
                    UserName = username,
                    Password = PasswordUtilities.ComputeHash(password),
                    RegistrationDate = DateTime.UtcNow
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool Find(string username, string password)
        {
            var passHash = PasswordUtilities.ComputeHash(password);
            using (var db = new ByTheCakeDbContext())
            {
                return db
                    .Users
                    .Any(u => u.UserName == username && (u.Password == passHash || u.Password == password)
                    );
            }
        }

        public ProfileViewModel Profile(string username)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db
                    .Users
                    .Where(u => u.UserName == username)
                    .Select(u => new ProfileViewModel
                    {
                        Username = u.UserName,
                        RegistrationDate = u.RegistrationDate,
                        TotalOrders = u.Orders.Count()
                    })
                    .FirstOrDefault(); 
            }
        }

        public int? GetUserId(string username)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var id = db
                    .Users
                    .Where(u => u.UserName == username)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                return id != 0 ? (int?)id : null;
            }
        }
    }
}

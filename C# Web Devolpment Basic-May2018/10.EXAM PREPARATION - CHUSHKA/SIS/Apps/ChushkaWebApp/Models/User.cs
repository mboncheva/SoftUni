using System.Collections.Generic;

namespace ChushkaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

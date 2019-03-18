namespace ChushkaWebApp.Data
{
    using ChushkaWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class ChushkaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        public ChushkaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Chushka;Integrated Security=True;");

        }
    }
}

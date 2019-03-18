namespace MusacaWebApp.Data
{
    using MusacaWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class MusakaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public MusakaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Musaka;Integrated Security=True;");

        }
    }
}

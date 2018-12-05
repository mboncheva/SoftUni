namespace MishMashWebApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using MishMashWebApp.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MishMash;Integrated Security=True;");
        }

    }
}

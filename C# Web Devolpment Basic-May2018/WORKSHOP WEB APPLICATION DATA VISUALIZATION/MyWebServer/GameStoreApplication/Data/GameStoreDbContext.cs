namespace MyWebServer.GameStoreApplication.Data
{
    using Microsoft.EntityFrameworkCore;
    using GameStoreApplication.Data.Models;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GameId });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                   .HasMany(u => u.Games)
                   .WithOne(ug => ug.User)
                   .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Game>()
                   .HasMany(g => g.Users)
                   .WithOne(ug => ug.Game)
                   .HasForeignKey(g => g.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

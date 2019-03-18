namespace PandaWebApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using PandaWebApp.Models;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Panda;Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                  .HasOne(r => r.Package)
                  .WithOne(p => p.Receipt)
                  .HasForeignKey<Receipt>(r => r.PackageId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

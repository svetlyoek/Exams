using Microsoft.EntityFrameworkCore;
using Panda.Models;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public PandaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public PandaDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(u => u.RecipientId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(u => u.RecipientId);

        }
    }
}

namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<UserTrip>()
                 .HasKey(pk => new { pk.UserId, pk.TripId });

            modelBuilder
                .Entity<UserTrip>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTrips)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<UserTrip>()
                .HasOne(ut => ut.Trip)
                .WithMany(t => t.UserTrips)
                .HasForeignKey(ut => ut.TripId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

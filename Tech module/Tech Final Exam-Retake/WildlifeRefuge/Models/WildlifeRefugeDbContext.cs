using Microsoft.EntityFrameworkCore;

namespace WildlifeRefuge.Models
{
    public class WildlifeRefugeDbContext : DbContext
    {
        public WildlifeRefugeDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Animal> Animals { get; set; }
        private const string ConnectionString = @"Server=DESKTOP-JH4M4M9;DataBase=WildlifeRefugeDbContext;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

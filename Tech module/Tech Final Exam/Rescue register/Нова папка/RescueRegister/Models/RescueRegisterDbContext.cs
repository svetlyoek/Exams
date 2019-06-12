using Microsoft.EntityFrameworkCore;

namespace RescueRegister.Models
{
    public class RescueRegisterDbContext : DbContext
    {
        public RescueRegisterDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Mountaineer> Mountaineers { get; set; }
        private const string ConnectionString = @"Server=DESKTOP-JH4M4M9;DataBase=RescueRegisterDbContext;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}

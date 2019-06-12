using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }

        private const string ConnectionString = @"Server=DESKTOP-JH4M4M9;Database=LibraryDbContext;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

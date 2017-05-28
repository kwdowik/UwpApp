using Microsoft.EntityFrameworkCore;
using UwpApp.Models;

namespace UwpApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private const string CONNECTION_STRING = "Data Source=UwpApp2.db";

        public DbSet<City> Cities { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>();
        }
    }
}

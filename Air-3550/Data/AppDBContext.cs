using Air_3550.Models;
using Microsoft.EntityFrameworkCore;

namespace Air_3550.Data
{
    /// <summary>
    /// Class for Database ?
    /// </summary>
    internal class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Air3550.db");
        }
    }
}
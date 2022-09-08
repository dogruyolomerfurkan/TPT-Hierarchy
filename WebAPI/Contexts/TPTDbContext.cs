using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Entities;

namespace WebAPI.Contexts
{
    public class TPTDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SS5IP2IG\\SQLEXPRESS;Database=TPTDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}

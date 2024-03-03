using AspNetCorePostgreSQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCorePostgreSQL.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Nothing to do here!
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                   .HasKey(e => new { e.Id }); // PK
        }
    }
}

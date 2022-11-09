using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Models;


namespace ProjetoFatec.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(e => e.Email).IsUnique();
        }
    }
}

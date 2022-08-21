using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Models;

namespace ProjetoFatec.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Logins { get; set; }
    }
}

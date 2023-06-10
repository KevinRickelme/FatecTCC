using Microsoft.EntityFrameworkCore;
using SI3.Domain.Entities;
using SI3.Infra.Data.EntityConfigurations;


namespace SI3.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Login { get; set; }
        public DbSet<Publicacao?> Publicacoes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<FotoPerfil> FotoPerfis { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            
        }
    }
}

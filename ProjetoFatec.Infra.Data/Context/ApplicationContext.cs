using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Infra.Data.EntityConfigurations;


namespace ProjetoFatec.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PublicacaoConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new FotoPerfilConfiguration());
        }
    }
}

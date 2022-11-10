using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProjetoFatec.Models;


namespace ProjetoFatec.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Login { get; set; }
        public DbSet<Publicacao> Publicacoes {get;set;}
        public DbSet<Perfil> Perfis {get;set;}
        public DbSet<FotoPerfil> FotoPerfis {get;set;}
        public DbSet<Foto> Fotos {get;set;}
        public DbSet<Feed> Feeds {get;set;}
        public DbSet<Comentario> Comentarios {get;set;}
        public DbSet<Amigo> Amigos {get;set;}

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(e => e.Email).IsUnique();

            modelBuilder.Entity<Publicacao>()
                .HasMany(p => p.Comentario)
                .WithOne(c => c.Publicacao);

            modelBuilder.Entity<Comentario>()
                .HasOne(p => p.Publicacao)
                .WithMany(c => c.Comentario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Foto>()
                .HasOne(f => f.Publicacao)
                .WithOne(p => p.Foto);

            modelBuilder.Entity<FotoPerfil>()
                .HasOne(fp => fp.Perfil)
                .WithOne(p => p.FotoPerfil);

        }
    }
}

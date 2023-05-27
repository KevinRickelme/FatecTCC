using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Infra.Data.EntityConfigurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> modelBuilder)
        {
            modelBuilder.HasKey(p => p.Id);
            modelBuilder.Property(p => p.Nome).HasMaxLength(255).IsRequired();
            modelBuilder.Property(p=>p.Sobrenome).HasMaxLength(255).IsRequired();
            modelBuilder.Property(p=>p.Telefone).HasMaxLength(11).IsRequired();
            modelBuilder.Property(p => p.DataNascimento).IsRequired();
            modelBuilder.Property(p => p.Sexo).IsRequired();
            modelBuilder.Property(p => p.Sobre);
            modelBuilder.Property(p => p.Sobre);

            modelBuilder.HasMany(p => p.Publicacoes).WithOne(p => p.Perfil).HasForeignKey(p=>p.Id);
            modelBuilder.HasMany(p => p.Comentarios).WithOne(p => p.Perfil).HasForeignKey(p => p.IdPerfil).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasOne(p => p.Usuario).WithOne(u => u.Perfil).HasForeignKey<Perfil>(u=>u.IdUsuario);
            modelBuilder.HasOne(p => p.Feed).WithOne(f => f.Perfil).HasForeignKey<Perfil>(f => f.IdFeed);

            modelBuilder.HasMany(p => p.Amigos).WithOne(a => a.PerfilSolicitante).HasForeignKey(a => a.IdPerfilSolicitante);
            //modelBuilder.HasMany(p => p.Amigos).WithOne(a => a.PerfilSolicitante).HasForeignKey(a => a.IdPerfilSolicitado);
        }
    }
}

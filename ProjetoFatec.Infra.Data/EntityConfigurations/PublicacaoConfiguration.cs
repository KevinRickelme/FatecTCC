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
    public class PublicacaoConfiguration : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> modelBuilder)
        {
            //modelBuilder.Property(p => p.Perfil);
            modelBuilder.HasMany(p => p.Comentarios).WithOne(c => c.Publicacao).HasForeignKey(p => p.IdPublicacao).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.HasMany(p => p.Curtidas).WithOne(c => c.Publicacao).HasForeignKey(p => p.IdPublicacao).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasOne(p=>p.Perfil).WithMany(p=>p.Publicacoes).HasForeignKey(p=>p.IdPerfil).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.HasOne(p => p.PublicacaoOriginal).WithMany().HasForeignKey(p => p.IdPublicacaoOriginal).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

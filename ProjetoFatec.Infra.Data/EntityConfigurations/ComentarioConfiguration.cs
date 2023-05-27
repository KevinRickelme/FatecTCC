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
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> modelBuilder)
        {

            modelBuilder.HasKey(c => c.Id);
            modelBuilder.Property(c => c.Descricao).IsRequired();
            modelBuilder.Property(c => c.DataComentario).IsRequired();

            modelBuilder.HasOne(c => c.Perfil).WithMany(p => p.Comentarios).HasForeignKey(p=>p.IdPerfil).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.HasOne(c => c.Publicacao).WithMany(p => p.Comentarios).HasForeignKey(c=>c.IdPublicacao).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

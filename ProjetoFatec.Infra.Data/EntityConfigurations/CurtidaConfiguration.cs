﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFatec.Domain.Entities;

namespace ProjetoFatec.Infra.Data.EntityConfigurations
{
    public class CurtidaConfiguration : IEntityTypeConfiguration<Curtida>
    {
        public void Configure(EntityTypeBuilder<Curtida> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder.HasOne(c => c.Publicacao).WithMany(p => p.Curtidas).HasForeignKey(c => c.IdPublicacao).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

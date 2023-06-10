using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Infra.Data.EntityConfigurations
{
    public class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> modelBuilder)
        {
            modelBuilder.HasKey(f => f.Id);

            modelBuilder.Property(f => f.CaminhoFoto).IsRequired();

        }
    }
}

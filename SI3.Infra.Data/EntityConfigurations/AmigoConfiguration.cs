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
    public class AmigoConfiguration : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder.HasOne(a => a.PerfilSolicitante).WithMany(p => p.Amigos).HasForeignKey(p=>p.IdPerfilSolicitante);
        }
    }
}

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
    public class FeedConfiguration : IEntityTypeConfiguration<Feed>
    {
        public void Configure(EntityTypeBuilder<Feed> modelBuilder)
        {
            modelBuilder.HasKey(f => f.Id);

            modelBuilder.HasOne(f => f.Perfil).WithOne(p => p.Feed).HasForeignKey<Feed>(c=>c.IdPerfil);

            
        }
    }
}

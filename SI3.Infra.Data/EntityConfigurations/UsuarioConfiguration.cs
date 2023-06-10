using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SI3.Domain.Entities;
using SI3.Domain.Enums;

namespace SI3.Infra.Data.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id);

            modelBuilder.HasIndex(u => u.Email).IsUnique();

            modelBuilder.Property(u => u.Status)
                .HasDefaultValue(StatusUsuarioEnum.Ativo).IsRequired();

            modelBuilder.Property(u => u.Privilegio)
                .HasDefaultValue(PrivilegioEnum.Padrao).IsRequired();

        }
    }
}

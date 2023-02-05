using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Enums;

namespace ProjetoFatec.Infra.Data.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder.HasIndex(u => u.Email).IsUnique();

            modelBuilder.Property(u => u.Status)
                .HasDefaultValue(StatusUsuarioEnum.Ativo);

            modelBuilder.Property(u => u.Privilegio)
                .HasDefaultValue(PrivilegioEnum.Padrao);
        }
    }
}

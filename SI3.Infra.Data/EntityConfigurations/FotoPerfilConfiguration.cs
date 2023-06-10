﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Infra.Data.EntityConfigurations
{
    public class FotoPerfilConfiguration : IEntityTypeConfiguration<FotoPerfil>
    {
        public void Configure(EntityTypeBuilder<FotoPerfil> modelBuilder)
        {
            modelBuilder.HasKey(fp => fp.Id);

            modelBuilder.Property(fp => fp.CaminhoFoto).IsRequired();

            modelBuilder.HasOne(fp => fp.Perfil).WithOne(p => p.FotoPerfil).HasForeignKey<Perfil>(p=>p.IdFotoPerfil);


        }
    }
}
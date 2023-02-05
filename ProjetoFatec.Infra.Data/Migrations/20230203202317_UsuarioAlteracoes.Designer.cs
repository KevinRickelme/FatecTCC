﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFatec.Infra.Data.Context;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230203202317_UsuarioAlteracoes")]
    partial class UsuarioAlteracoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAmizade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAmizade");

                    b.Property<int>("IdPerfilSolicitante")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfilSolicitante");

                    b.ToTable("Amigo");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataComentario")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataComentario");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<int>("IdPublicacao")
                        .HasColumnType("int");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPublicacao");

                    b.HasIndex("PerfilId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Feed");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CaminhoFoto");

                    b.Property<int>("PublicacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublicacaoId");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.FotoPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CaminhoFoto");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil")
                        .IsUnique();

                    b.ToTable("FotoPerfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Biografia");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeCurso");

                    b.Property<int>("SemestreAtual")
                        .HasColumnType("int")
                        .HasColumnName("SemestreAtual");

                    b.Property<int>("Sexo")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("Sexo");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Sobrenome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<int?>("FeedId")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Legenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Legenda");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email");

                    b.Property<int>("Privilegio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Privilegio");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Amigo", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "PerfilSolicitante")
                        .WithMany()
                        .HasForeignKey("IdPerfilSolicitante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilSolicitante");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Publicacao", "Publicacao")
                        .WithMany("Comentario")
                        .HasForeignKey("IdPublicacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Feed", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Foto", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Publicacao", "Publicacao")
                        .WithMany()
                        .HasForeignKey("PublicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.FotoPerfil", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithOne("FotoPerfil")
                        .HasForeignKey("ProjetoFatec.Domain.Entities.FotoPerfil", "IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Feed", null)
                        .WithMany("Publicacao")
                        .HasForeignKey("FeedId");

                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Feed", b =>
                {
                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("FotoPerfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.Navigation("Comentario");
                });
#pragma warning restore 612, 618
        }
    }
}

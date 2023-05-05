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
    [Migration("20230421160730_FeedUnicoPorPerfil")]
    partial class FeedUnicoPorPerfil
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAmizade")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataComentario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int>("IdPublicacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPublicacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.FotoPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FotoPerfis");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFeed")
                        .HasColumnType("int");

                    b.Property<int?>("IdFotoPerfil")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemestreAtual")
                        .HasColumnType("int");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdFeed")
                        .IsUnique();

                    b.HasIndex("IdFotoPerfil")
                        .IsUnique()
                        .HasFilter("[IdFotoPerfil] IS NOT NULL");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaminhoFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FeedId")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Legenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int>("Privilegio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Amigo", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "PerfilSolicitante")
                        .WithMany("Amigos")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilSolicitante");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Comentarios")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjetoFatec.Domain.Entities.Publicacao", "Publicacao")
                        .WithMany("Comentarios")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Feed", "Feed")
                        .WithOne("Perfil")
                        .HasForeignKey("ProjetoFatec.Domain.Entities.Perfil", "IdFeed")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFatec.Domain.Entities.FotoPerfil", "FotoPerfil")
                        .WithOne("Perfil")
                        .HasForeignKey("ProjetoFatec.Domain.Entities.Perfil", "IdFotoPerfil");

                    b.HasOne("ProjetoFatec.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Perfil")
                        .HasForeignKey("ProjetoFatec.Domain.Entities.Perfil", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("FotoPerfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.HasOne("ProjetoFatec.Domain.Entities.Feed", null)
                        .WithMany("Publicacões")
                        .HasForeignKey("FeedId");

                    b.HasOne("ProjetoFatec.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Publicacoes")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Feed", b =>
                {
                    b.Navigation("Perfil")
                        .IsRequired();

                    b.Navigation("Publicacões");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.FotoPerfil", b =>
                {
                    b.Navigation("Perfil")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Amigos");

                    b.Navigation("Comentarios");

                    b.Navigation("Publicacoes");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Publicacao", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("ProjetoFatec.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Perfil")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

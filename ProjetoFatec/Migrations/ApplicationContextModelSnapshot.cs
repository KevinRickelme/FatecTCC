﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFatec.Data;

#nullable disable

namespace ProjetoFatec.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFatec.Models.Amigo", b =>
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

            modelBuilder.Entity("ProjetoFatec.Models.Comentario", b =>
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

            modelBuilder.Entity("ProjetoFatec.Models.Feed", b =>
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

            modelBuilder.Entity("ProjetoFatec.Models.Foto", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("ProjetoFatec.Models.FotoPerfil", b =>
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

            modelBuilder.Entity("ProjetoFatec.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biografia")
                        .IsRequired()
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

            modelBuilder.Entity("ProjetoFatec.Models.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<int?>("FeedId")
                        .HasColumnType("int");

                    b.Property<int>("IdFoto")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Legenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Legenda");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("IdFoto")
                        .IsUnique();

                    b.HasIndex("IdPerfil");

                    b.ToTable("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Usuario", b =>
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
                        .HasColumnType("int")
                        .HasColumnName("Privilegio");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Amigo", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Perfil", "PerfilSolicitante")
                        .WithMany()
                        .HasForeignKey("IdPerfilSolicitante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilSolicitante");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Comentario", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Publicacao", "Publicacao")
                        .WithMany("Comentario")
                        .HasForeignKey("IdPublicacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjetoFatec.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Feed", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Models.FotoPerfil", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Perfil", "Perfil")
                        .WithOne("FotoPerfil")
                        .HasForeignKey("ProjetoFatec.Models.FotoPerfil", "IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Perfil", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Publicacao", b =>
                {
                    b.HasOne("ProjetoFatec.Models.Feed", null)
                        .WithMany("Publicacao")
                        .HasForeignKey("FeedId");

                    b.HasOne("ProjetoFatec.Models.Foto", "Foto")
                        .WithOne("Publicacao")
                        .HasForeignKey("ProjetoFatec.Models.Publicacao", "IdFoto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFatec.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Foto");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Feed", b =>
                {
                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("ProjetoFatec.Models.Foto", b =>
                {
                    b.Navigation("Publicacao")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFatec.Models.Perfil", b =>
                {
                    b.Navigation("FotoPerfil")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFatec.Models.Publicacao", b =>
                {
                    b.Navigation("Comentario");
                });
#pragma warning restore 612, 618
        }
    }
}

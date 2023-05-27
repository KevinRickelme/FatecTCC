using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class arrumandocomentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotoPerfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoPerfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublicacao = table.Column<int>(type: "int", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Privilegio = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFotoPerfil = table.Column<int>(type: "int", nullable: true),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemestreAtual = table.Column<int>(type: "int", nullable: false),
                    IdFeed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfis_Feeds_IdFeed",
                        column: x => x.IdFeed,
                        principalTable: "Feeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Perfis_FotoPerfis_IdFotoPerfil",
                        column: x => x.IdFotoPerfil,
                        principalTable: "FotoPerfis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Perfis_Login_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Login",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfilSolicitante = table.Column<int>(type: "int", nullable: false),
                    IdPerfilSolicitado = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataAmizade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amigos_Perfis_IdPerfilSolicitante",
                        column: x => x.IdPerfilSolicitante,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    Legenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Publicacoes_Perfis_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPublicacao = table.Column<int>(type: "int", nullable: false),
                    DataComentario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Perfis_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacoes_IdPublicacao",
                        column: x => x.IdPublicacao,
                        principalTable: "Publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_IdPerfilSolicitante",
                table: "Amigos",
                column: "IdPerfilSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPerfil",
                table: "Comentarios",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPublicacao",
                table: "Comentarios",
                column: "IdPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Email",
                table: "Login",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis",
                column: "IdFeed",
                unique: true,
                filter: "[IdFeed] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFotoPerfil",
                table: "Perfis",
                column: "IdFotoPerfil",
                unique: true,
                filter: "[IdFotoPerfil] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdUsuario",
                table: "Perfis",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_FeedId",
                table: "Publicacoes",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdPerfil",
                table: "Publicacoes",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "FotoPerfis");

            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}

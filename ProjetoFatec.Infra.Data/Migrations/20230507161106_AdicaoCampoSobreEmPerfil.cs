using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class AdicaoCampoSobreEmPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Perfis_IdPerfilSolicitado",
                table: "Amigos");

            migrationBuilder.DropIndex(
                name: "IX_Amigos_IdPerfilSolicitado",
                table: "Amigos");

            migrationBuilder.AddColumn<string>(
                name: "Sobre",
                table: "Perfis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_IdPerfilSolicitante",
                table: "Amigos",
                column: "IdPerfilSolicitante");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Perfis_IdPerfilSolicitante",
                table: "Amigos",
                column: "IdPerfilSolicitante",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Perfis_IdPerfilSolicitante",
                table: "Amigos");

            migrationBuilder.DropIndex(
                name: "IX_Amigos_IdPerfilSolicitante",
                table: "Amigos");

            migrationBuilder.DropColumn(
                name: "Sobre",
                table: "Perfis");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_IdPerfilSolicitado",
                table: "Amigos",
                column: "IdPerfilSolicitado");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Perfis_IdPerfilSolicitado",
                table: "Amigos",
                column: "IdPerfilSolicitado",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

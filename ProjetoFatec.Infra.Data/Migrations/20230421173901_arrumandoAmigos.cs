using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class arrumandoAmigos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Perfis_IdPerfil",
                table: "Amigos");

            migrationBuilder.RenameColumn(
                name: "IdPerfil",
                table: "Amigos",
                newName: "IdPerfilSolicitante");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_IdPerfil",
                table: "Amigos",
                newName: "IX_Amigos_IdPerfilSolicitante");

            migrationBuilder.AddColumn<int>(
                name: "IdPerfilSolicitado",
                table: "Amigos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "IdPerfilSolicitado",
                table: "Amigos");

            migrationBuilder.RenameColumn(
                name: "IdPerfilSolicitante",
                table: "Amigos",
                newName: "IdPerfil");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_IdPerfilSolicitante",
                table: "Amigos",
                newName: "IX_Amigos_IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Perfis_IdPerfil",
                table: "Amigos",
                column: "IdPerfil",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

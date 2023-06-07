using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class CompartilhamentoDePublicacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Compartilhado",
                table: "Publicacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdPerfilQueCompartilhou",
                table: "Publicacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdPerfilQueCompartilhou",
                table: "Publicacoes",
                column: "IdPerfilQueCompartilhou");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Perfis_IdPerfilQueCompartilhou",
                table: "Publicacoes",
                column: "IdPerfilQueCompartilhou",
                principalTable: "Perfis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Perfis_IdPerfilQueCompartilhou",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_IdPerfilQueCompartilhou",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "Compartilhado",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "IdPerfilQueCompartilhou",
                table: "Publicacoes");
        }
    }
}

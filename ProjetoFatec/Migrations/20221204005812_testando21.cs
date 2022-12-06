using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Migrations
{
    public partial class testando21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Foto_IdFoto",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Publicacao_IdFoto",
                table: "Publicacao");

            migrationBuilder.DropColumn(
                name: "IdFoto",
                table: "Publicacao");

            migrationBuilder.AddColumn<int>(
                name: "PublicacaoId",
                table: "Foto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFoto",
                table: "Comentario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_PublicacaoId",
                table: "Foto",
                column: "PublicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Publicacao_PublicacaoId",
                table: "Foto",
                column: "PublicacaoId",
                principalTable: "Publicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Publicacao_PublicacaoId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_PublicacaoId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "PublicacaoId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "IdFoto",
                table: "Comentario");

            migrationBuilder.AddColumn<int>(
                name: "IdFoto",
                table: "Publicacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_IdFoto",
                table: "Publicacao",
                column: "IdFoto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Foto_IdFoto",
                table: "Publicacao",
                column: "IdFoto",
                principalTable: "Foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

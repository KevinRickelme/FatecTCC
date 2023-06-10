using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SI3.Infra.Data.Migrations
{
    public partial class CurtidaDePublicacaoes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_PublicacaoId",
                table: "Curtidas");

            migrationBuilder.DropColumn(
                name: "PublicacaoId",
                table: "Curtidas");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Curtidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdPublicacao",
                table: "Curtidas",
                column: "IdPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PerfilId",
                table: "Curtidas",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Perfis_PerfilId",
                table: "Curtidas",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_IdPublicacao",
                table: "Curtidas",
                column: "IdPublicacao",
                principalTable: "Publicacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Perfis_PerfilId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_IdPublicacao",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_IdPublicacao",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_PerfilId",
                table: "Curtidas");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Curtidas");

            migrationBuilder.AddColumn<int>(
                name: "PublicacaoId",
                table: "Curtidas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PublicacaoId",
                table: "Curtidas",
                column: "PublicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId",
                table: "Curtidas",
                column: "PublicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "Id");
        }
    }
}

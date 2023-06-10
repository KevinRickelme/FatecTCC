using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SI3.Infra.Data.Migrations
{
    public partial class CompartilhamentoDePublicacoes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdPublicacaoOriginal",
                table: "Publicacoes",
                column: "IdPublicacaoOriginal");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Publicacoes_IdPublicacaoOriginal",
                table: "Publicacoes",
                column: "IdPublicacaoOriginal",
                principalTable: "Publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Publicacoes_IdPublicacaoOriginal",
                table: "Publicacoes");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_IdPublicacaoOriginal",
                table: "Publicacoes");
        }
    }
}

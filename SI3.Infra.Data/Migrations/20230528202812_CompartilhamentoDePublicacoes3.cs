using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SI3.Infra.Data.Migrations
{
    public partial class CompartilhamentoDePublicacoes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPublicacaoOriginal",
                table: "Publicacoes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPublicacaoOriginal",
                table: "Publicacoes");
        }
    }
}

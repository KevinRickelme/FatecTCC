using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class FeedUnicoPorPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Perfis_IdPerfil",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_IdPerfil",
                table: "Feeds");

            migrationBuilder.AddColumn<int>(
                name: "IdFeed",
                table: "Perfis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis",
                column: "IdFeed",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Feeds_IdFeed",
                table: "Perfis",
                column: "IdFeed",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Feeds_IdFeed",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "IdFeed",
                table: "Perfis");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_IdPerfil",
                table: "Feeds",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Perfis_IdPerfil",
                table: "Feeds",
                column: "IdPerfil",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

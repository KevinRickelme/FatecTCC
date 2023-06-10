using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SI3.Infra.Data.Migrations
{
    public partial class CurtidaDePublicacaoes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Perfis_PerfilId",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_PerfilId",
                table: "Curtidas");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Curtidas");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdPerfil",
                table: "Curtidas",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Perfis_IdPerfil",
                table: "Curtidas",
                column: "IdPerfil",
                principalTable: "Perfis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Perfis_IdPerfil",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_IdPerfil",
                table: "Curtidas");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Curtidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}

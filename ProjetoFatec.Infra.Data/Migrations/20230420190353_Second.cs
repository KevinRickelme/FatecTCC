using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_FotoPerfis_IdFotoPerfil",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdFotoPerfil",
                table: "Perfis");

            migrationBuilder.AlterColumn<int>(
                name: "IdFotoPerfil",
                table: "Perfis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFotoPerfil",
                table: "Perfis",
                column: "IdFotoPerfil",
                unique: true,
                filter: "[IdFotoPerfil] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_FotoPerfis_IdFotoPerfil",
                table: "Perfis",
                column: "IdFotoPerfil",
                principalTable: "FotoPerfis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_FotoPerfis_IdFotoPerfil",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdFotoPerfil",
                table: "Perfis");

            migrationBuilder.AlterColumn<int>(
                name: "IdFotoPerfil",
                table: "Perfis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFotoPerfil",
                table: "Perfis",
                column: "IdFotoPerfil",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_FotoPerfis_IdFotoPerfil",
                table: "Perfis",
                column: "IdFotoPerfil",
                principalTable: "FotoPerfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

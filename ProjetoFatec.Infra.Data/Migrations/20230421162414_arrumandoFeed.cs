using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Infra.Data.Migrations
{
    public partial class arrumandoFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Feeds_IdFeed",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis");

            migrationBuilder.AlterColumn<int>(
                name: "IdFeed",
                table: "Perfis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis",
                column: "IdFeed",
                unique: true,
                filter: "[IdFeed] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Feeds_IdFeed",
                table: "Perfis",
                column: "IdFeed",
                principalTable: "Feeds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Feeds_IdFeed",
                table: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_IdFeed",
                table: "Perfis");

            migrationBuilder.AlterColumn<int>(
                name: "IdFeed",
                table: "Perfis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}

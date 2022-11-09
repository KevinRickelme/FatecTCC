using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Migrations
{
    public partial class NovasClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Login_Email",
                table: "Usuario",
                newName: "IX_Usuario_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Login");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_Email",
                table: "Login",
                newName: "IX_Login_Email");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "Id");
        }
    }
}

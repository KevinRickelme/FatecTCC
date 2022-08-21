using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Migrations
{
    public partial class AlterandoTableUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Logins",
                newName: "UsuarioSenha");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Logins",
                newName: "UsuarioNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioSenha",
                table: "Logins",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Logins",
                newName: "Password");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Migrations
{
    public partial class MigrationAlteracoesUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "PrimeiroAcesso",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Logins");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "UsuarioSenha",
                table: "Login",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Login",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Login",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Email",
                table: "Login",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_Email",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Logins");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Logins",
                newName: "UsuarioSenha");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "PrimeiroAcesso",
                table: "Logins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "Id");
        }
    }
}

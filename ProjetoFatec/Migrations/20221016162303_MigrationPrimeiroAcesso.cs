using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFatec.Migrations
{
    public partial class MigrationPrimeiroAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrimeiroAcesso",
                table: "Logins",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimeiroAcesso",
                table: "Logins");
        }
    }
}

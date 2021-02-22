using Microsoft.EntityFrameworkCore.Migrations;

namespace Coti.Infrastructure.Context.Migrations
{
    public partial class Inclusao_Do_Campo_CPF_Em_Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Funcionario",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Funcionario");
        }
    }
}

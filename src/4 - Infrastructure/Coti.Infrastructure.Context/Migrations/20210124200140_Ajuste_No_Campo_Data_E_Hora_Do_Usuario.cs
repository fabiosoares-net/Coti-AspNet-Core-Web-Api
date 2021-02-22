using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coti.Infrastructure.Context.Migrations
{
    public partial class Ajuste_No_Campo_Data_E_Hora_Do_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCadastro",
                table: "Usuario",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCadastro",
                table: "Usuario",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}

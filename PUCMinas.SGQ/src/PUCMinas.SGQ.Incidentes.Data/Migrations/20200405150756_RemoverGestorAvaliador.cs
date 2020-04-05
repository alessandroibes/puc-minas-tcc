using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Incidentes.Data.Migrations
{
    public partial class RemoverGestorAvaliador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GestorAvaliador",
                table: "RNCs");

            migrationBuilder.AlterColumn<Guid>(
                name: "EngenheiroResponsavel",
                table: "RNCs",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EngenheiroResponsavel",
                table: "RNCs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GestorAvaliador",
                table: "RNCs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

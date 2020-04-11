using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Processos.Data.Migrations
{
    public partial class RemoverOrdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "PassosDefinicao");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Paradas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "PassosDefinicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Paradas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

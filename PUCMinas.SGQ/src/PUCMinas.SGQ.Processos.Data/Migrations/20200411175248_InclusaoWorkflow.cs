using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Processos.Data.Migrations
{
    public partial class InclusaoWorkflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Workflows",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Passos",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Passos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Passos");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Passos");
        }
    }
}

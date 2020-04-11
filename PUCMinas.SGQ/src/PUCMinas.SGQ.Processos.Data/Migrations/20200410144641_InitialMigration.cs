using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Processos.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: true),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Iniciado = table.Column<bool>(nullable: false),
                    Finalizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowsDefinicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    EngenherioCriadorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowsDefinicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    WorflowId = table.Column<Guid>(nullable: false),
                    OperadorId = table.Column<Guid>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: true),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Iniciado = table.Column<bool>(nullable: false),
                    Finalizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passos_Workflows_WorflowId",
                        column: x => x.WorflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassosDefinicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    WorkflowDefinicaoId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Ordem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassosDefinicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassosDefinicao_WorkflowsDefinicao_WorkflowDefinicaoId",
                        column: x => x.WorkflowDefinicaoId,
                        principalTable: "WorkflowsDefinicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    PassoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    OperadorId = table.Column<Guid>(nullable: false),
                    IncidenteCadastrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paradas_Passos_PassoId",
                        column: x => x.PassoId,
                        principalTable: "Passos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_PassoId",
                table: "Paradas",
                column: "PassoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passos_WorflowId",
                table: "Passos",
                column: "WorflowId");

            migrationBuilder.CreateIndex(
                name: "IX_PassosDefinicao_WorkflowDefinicaoId",
                table: "PassosDefinicao",
                column: "WorkflowDefinicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropTable(
                name: "PassosDefinicao");

            migrationBuilder.DropTable(
                name: "Passos");

            migrationBuilder.DropTable(
                name: "WorkflowsDefinicao");

            migrationBuilder.DropTable(
                name: "Workflows");
        }
    }
}

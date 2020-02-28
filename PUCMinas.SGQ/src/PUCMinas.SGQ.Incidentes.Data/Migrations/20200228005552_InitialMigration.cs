using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Incidentes.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Causas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gravidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gravidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RNCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    GravidadeId = table.Column<Guid>(nullable: false),
                    CausaId = table.Column<Guid>(nullable: false),
                    AcaoId = table.Column<Guid>(nullable: false),
                    Ocorrencia = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    GerenteCriador = table.Column<Guid>(nullable: false),
                    Classificacao = table.Column<int>(nullable: false),
                    EngenheiroResponsavel = table.Column<Guid>(nullable: false),
                    GestorAvaliador = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Prazo = table.Column<DateTime>(nullable: false),
                    DataOcorrencia = table.Column<DateTime>(nullable: false),
                    DataResolucao = table.Column<DateTime>(nullable: false),
                    DataFechamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RNCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RNCs_Acoes_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "Acoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RNCs_Causas_CausaId",
                        column: x => x.CausaId,
                        principalTable: "Causas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RNCs_Gravidades_GravidadeId",
                        column: x => x.GravidadeId,
                        principalTable: "Gravidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RNCs_AcaoId",
                table: "RNCs",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RNCs_CausaId",
                table: "RNCs",
                column: "CausaId");

            migrationBuilder.CreateIndex(
                name: "IX_RNCs_GravidadeId",
                table: "RNCs",
                column: "GravidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RNCs");

            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "Causas");

            migrationBuilder.DropTable(
                name: "Gravidades");
        }
    }
}

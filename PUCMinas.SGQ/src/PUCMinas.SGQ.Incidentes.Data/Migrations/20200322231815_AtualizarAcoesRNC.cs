﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUCMinas.SGQ.Incidentes.Data.Migrations
{
    public partial class AtualizarAcoesRNC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AcaoId",
                table: "RNCs",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AcaoId",
                table: "RNCs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PUCMinas.SGQ.Incidentes.Data.Migrations
{
    public partial class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(string.Format("INSERT INTO Acoes(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Nenhuma medida de controle')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Acoes(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Treinamento de conscientização do uso correto do EPI')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Acoes(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Campanha de segurança no trabalho com o uso correto do EPI')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Acoes(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Fazer manutenção preventiva de tempos em tempos para garantir a segurança dos funcionários')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Acoes(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Fazer a substituição do equipamento por um mais moderno')", Guid.NewGuid(), DateTime.Now));

            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Não utilização do EPI')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Defeito na ponte rolante')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Equipamento sem proteção')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Operador sem capacitação')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Utilização de andaime inadequada')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Causas(Id, DataCriacao, Nome) VALUES ('{0}',getdate(),'Matérias primas de baixa qualidade')", Guid.NewGuid(), DateTime.Now));

            mb.Sql(string.Format("INSERT INTO Gravidades(Id, DataCriacao, Nome, Descricao) VALUES ('{0}',getdate(),'Ausente','O risco gerado na execução da atividade não ocasiona perdas em termos de saúde e segurança do colaborador')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Gravidades(Id, DataCriacao, Nome, Descricao) VALUES ('{0}',getdate(),'Baixa','O risco gerado na execução da atividade pode ocasionar pequenas perdas em termos de saúde e segurança do colaborador')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Gravidades(Id, DataCriacao, Nome, Descricao) VALUES ('{0}',getdate(),'Moderada','O risco gerado na execução da atividade pode ocasionar perdas moderadas em termos de saúde e segurança do colaborador')", Guid.NewGuid(), DateTime.Now));
            mb.Sql(string.Format("INSERT INTO Gravidades(Id, DataCriacao, Nome, Descricao) VALUES ('{0}',getdate(),'Elevada','O risco gerado na execução da atividade pode ocasionar grandes perdas em termos de saúde e segurança do colaborador')", Guid.NewGuid(), DateTime.Now));
        }

        protected override void Down(MigrationBuilder bm)
        {
            bm.Sql("DELETE FROM Acoes");
            bm.Sql("DELETE FROM Causas");
            bm.Sql("DELETE FROM Gravidades");
        }
    }
}

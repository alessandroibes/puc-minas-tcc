using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class PassoDefinicao : Entity
    {
        public Guid WorkflowDefinicaoId { get; set; }
        public Guid AtividadeId { get; set; }
        public int Ordem { get; set; }

        /* EF Relations */
        public WorkflowDefinicao WorkflowDefinicao { get; set; }
        public Atividade Atividade { get; set; }
    }
}

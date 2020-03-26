using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class Passo : Entity
    {
        public Guid WorflowId { get; set; }
        public Guid PassoDefinicaoId { get; set; }
        public Guid ParadaId { get; set; }
        public Guid OperadorId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        /* EF Relations */
        public Workflow Workflow { get; set; }
        public Parada Parada { get; set; }
    }
}

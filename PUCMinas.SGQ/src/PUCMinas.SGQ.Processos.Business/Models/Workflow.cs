using PUCMinas.SGQ.Core.Business.Models;
using System;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class Workflow : Entity
    {
        public Guid WorkflowDefinicaoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        /* EF Relations */
        public IEnumerable<Passo> Passos { get; set; }
    }
}

using PUCMinas.SGQ.Core.Business.Models;
using System;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class WorkflowDefinicao : Entity
    {
        public string Nome { get; set; }
        public Guid EngenherioCriador { get; set; }

        /* EF Relations */
        public IEnumerable<PassoDefinicao> PassosDefinicao { get; set; }
    }
}

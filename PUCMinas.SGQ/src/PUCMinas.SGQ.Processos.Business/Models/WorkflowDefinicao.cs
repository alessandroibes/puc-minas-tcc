using PUCMinas.SGQ.Core.Business.Models;
using System;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    /// <summary>
    /// Representa a definição (modelo) de workflow.
    /// </summary>
    public class WorkflowDefinicao : Entity
    {
        /// <summary>
        /// Nome do workflow.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Engenheiro que criou o template.
        /// </summary>
        public Guid EngenherioCriadorId { get; set; }
        /// <summary>
        /// O workflow é formado por uma lista de passos (atividades) que devem
        /// ser executados. Esta propriedade representa a lista de definições (modelos) 
        /// dos passos do workflow.
        /// </summary>
        public IEnumerable<PassoDefinicao> PassosDefinicao { get; set; }
    }
}

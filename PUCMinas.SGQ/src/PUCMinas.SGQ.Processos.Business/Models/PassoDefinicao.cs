using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    /// <summary>
    /// Representa a definição de um passo de workflow.
    /// </summary>
    public class PassoDefinicao : Entity
    {
        /// <summary>
        /// Identificador da definição de workflow a qual este passo faz parte.
        /// </summary>
        public Guid WorkflowDefinicaoId { get; set; }

        /// <summary>
        /// Títul da atividade.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da atividade.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Ordem de execução do passo dentro do workflow.
        /// </summary>
        public int Ordem { get; set; }

        /* EF Relations */
        /// <summary>
        /// Definição de workflow a qual este passo faz parte.
        /// </summary>
        public WorkflowDefinicao WorkflowDefinicao { get; set; }
    }
}

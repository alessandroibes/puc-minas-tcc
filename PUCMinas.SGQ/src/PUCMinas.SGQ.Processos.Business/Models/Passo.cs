using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    /// <summary>
    /// Representa um passo de um workflow em execução.
    /// </summary>
    public class Passo : Entity
    {
        /// <summary>
        /// Identificador do workflow ao qual este passo faz parte.
        /// </summary>
        public Guid WorflowId { get; set; }
        /// <summary>
        /// Títul da atividade.
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Descrição da atividade.
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Identificador do operador que executou este passo.
        /// </summary>
        public Guid OperadorId { get; set; }
        /// <summary>
        /// Data de início da execução deste passo.
        /// </summary>
        public DateTime? DataInicio { get; set; }
        /// <summary>
        /// Data de término da execução deste passo.
        /// </summary>
        public DateTime? DataFim { get; set; }
        /// <summary>
        /// Indica se este passo começou a ser executado.
        /// </summary>
        public bool Iniciado { get; set; }
        /// <summary>
        /// Indica se a execução deste passo já foi finalizado.
        /// </summary>
        public bool Finalizado { get; set; }
        /// <summary>
        /// Representa uma parada ocorrida durante a execução deste passo.
        /// </summary>
        public Parada Parada { get; set; }

        /* EF Relations */
        /// <summary>
        /// Representa o workflow ao qual este passo faz parte.
        /// </summary>
        public Workflow Workflow { get; set; }
    }
}

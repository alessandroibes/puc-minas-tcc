using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    /// <summary>
    /// Representa uma parada ocorrida durante a execução de um passo.
    /// </summary>
    public class Parada : Entity
    {
        /// <summary>
        /// Identificador do passo onde esta parada ocorreu.
        /// </summary>
        public Guid PassoId { get; set; }
        /// <summary>
        /// Descrição da parada.
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Data em que a parada ocorreu.
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// Identificador do operador que cadastrou esta parada.
        /// </summary>
        public Guid OperadorId { get; set; }
        /// <summary>
        /// Indica se já foi cadastrado incidente relacionado a esta parada.
        /// </summary>
        public bool IncidenteCadastrado { get; set; }

        /* EF Relation */
        /// <summary>
        /// Representa o passo onde esta parada ocorreu.
        /// </summary>
        public Passo Passo { get; set; }
    }
}

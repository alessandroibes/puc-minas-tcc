using PUCMinas.SGQ.Core.Business.Models;
using System;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    /// <summary>
    /// Representa um worflow em execução.
    /// </summary>
    public class Workflow : Entity
    {
        /// <summary>
        /// Nome do workflow.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Data de início do primeiro passo (atividade) do workflow.
        /// </summary>
        public DateTime? DataInicio { get; set; }
        /// <summary>
        /// Data de termino do último passo do workflow.
        /// </summary>
        public DateTime? DataFim { get; set; }
        /// <summary>
        /// Indica se o workflow começou a ser executado.
        /// Esta propriedade se torna verdadeiro quando o primeiro
        /// passo do workflow começa a ser executado.
        /// </summary>
        public bool Iniciado { get; set; }
        /// <summary>
        /// Indica se todos os passos do workflow foram finalizados.
        /// </summary>
        public bool Finalizado { get; set; }
        /// <summary>
        /// Representa a lista de passos do workflow.
        /// </summary>
        public IEnumerable<Passo> Passos { get; set; }
    }
}

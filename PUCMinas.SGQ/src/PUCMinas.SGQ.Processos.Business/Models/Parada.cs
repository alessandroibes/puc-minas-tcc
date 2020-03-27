using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class Parada : Entity
    {
        public Guid PassoId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Guid OperadorId { get; set; }
        public bool IncidenteCadastrado { get; set; }

        /* EF Relation */
        public Passo Passo { get; set; }
    }
}

using PUCMinas.SGQ.Core.Business.Models;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Incidentes.Business.Models
{
    public class Gravidade : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public IEnumerable<RNC> RNCs { get; set; }
    }
}

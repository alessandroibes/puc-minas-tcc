using PUCMinas.SGQ.Core.Business.Models;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Incidentes.Business.Models
{
    public class Acao : Entity
    {
        public string Nome { get; set; }

        /* EF Relation */
        public IEnumerable<RNC> RNCs { get; set; }
    }
}

using PUCMinas.SGQ.Core.Business.Models;
using System.Collections.Generic;

namespace PUCMinas.SGQ.Processos.Business.Models
{
    public class Atividade : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public IEnumerable<PassoDefinicao> PassoDefinicoes { get; set; }
    }
}

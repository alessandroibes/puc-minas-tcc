using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface INaoConformidadeRepository : IRepository<RNC>
    {
        Task<IEnumerable<RNC>> ObterNaoConformidadePorStatus(StatusRNC status);
    }
}

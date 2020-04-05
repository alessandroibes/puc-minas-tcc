using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IRNCRepository : IRepository<RNC>
    {
        Task<IEnumerable<RNC>> ObterRNCPorStatus(StatusRNC status);
        Task<IEnumerable<RNC>> ObterRNCComObjetos();
        Task<RNC> ObterRNCPorIdComObjetos(Guid id);
    }
}

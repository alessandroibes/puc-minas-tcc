using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IGravidadeRepository : IRepository<Gravidade>
    {
        Task<Gravidade> ObterGravidadeComRNCs(Guid id);
    }
}

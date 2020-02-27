using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class NaoConformidadeRepository : Repository<RNC>, INaoConformidadeRepository
    {
        public NaoConformidadeRepository(IncidentesDbContext context) : base(context) { }

        public Task<IEnumerable<RNC>> ObterNaoConformidadePorStatus(StatusRNC status)
        {
            throw new NotImplementedException();
        }
    }
}

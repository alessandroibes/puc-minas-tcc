using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class AcaoRepository : Repository<Acao>, IAcaoRepository
    {
        public AcaoRepository(IncidentesDbContext context) : base(context) { }
    }
}

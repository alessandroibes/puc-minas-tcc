using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class CausaRepository : Repository<Causa>, ICausaRepository
    {
        public CausaRepository(IncidentesDbContext context) : base(context) { }

        public async Task<Causa> ObterCausaComRNCs(Guid id)
        {
            return await(Db as IncidentesDbContext).Causas
                .Include(a => a.RNCs)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

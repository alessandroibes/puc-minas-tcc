using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class RNCRepository : Repository<RNC>, IRNCRepository
    {
        public RNCRepository(IncidentesDbContext context) : base(context) { }

        public async Task<IEnumerable<RNC>> ObterRNCStatus(StatusRNC status)
        {
            return await (Context as IncidentesDbContext).RNCs.AsNoTracking().Include(i => i.Status == status)
                .OrderBy(i => i.Prazo).ToListAsync();
        }
    }
}

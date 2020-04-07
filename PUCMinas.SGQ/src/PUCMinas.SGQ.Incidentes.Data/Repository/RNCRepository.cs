using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class RNCRepository : Repository<RNC>, IRNCRepository
    {
        public RNCRepository(IncidentesDbContext context) : base(context) { }

        public async Task<IEnumerable<RNC>> ObterRNCComObjetos()
        {
            return await (Db as IncidentesDbContext).RNCs
                .Include(g => g.Gravidade)
                .Include(c => c.Causa)
                .Include(a => a.Acao)                
                .OrderBy(i => i.Prazo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RNC> ObterRNCPorIdComObjetos(Guid id)
        {
            return await (Db as IncidentesDbContext).RNCs
                .Include(g => g.Gravidade)
                .Include(c => c.Causa)
                .Include(a => a.Acao)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RNC>> ObterRNCPorStatus(StatusRNC status)
        {
            return await (Db as IncidentesDbContext).RNCs
                .Include(i => i.Status == status)
                .Include(g => g.Gravidade)
                .Include(c => c.Causa)
                .Include(a => a.Acao)
                .OrderBy(i => i.Prazo)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Incidentes.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.Data.Context;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Repository
{
    public class GravidadeRepository : Repository<Gravidade>, IGravidadeRepository
    {
        public GravidadeRepository(IncidentesDbContext context) : base(context) { }

        public async Task<Gravidade> ObterGravidadeComRNCs(Guid id)
        {
            return await (Db as IncidentesDbContext).Gravidades
                .AsNoTracking()
                .Include(a => a.RNCs)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

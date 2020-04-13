using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Data.Repository
{
    public class WorkflowRepository : Repository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(ProcessosDbContext context) : base(context) { }

        public async Task<Workflow> ObterPorIdComObjetos(Guid id)
        {
            return await (Db as ProcessosDbContext).Workflows
                .Include(w => w.Passos).ThenInclude(p => p.Parada)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Workflow>> ObterTodosEmAndamento()
        {
            return await Buscar(w => w.Finalizado == false);
        }
    }
}

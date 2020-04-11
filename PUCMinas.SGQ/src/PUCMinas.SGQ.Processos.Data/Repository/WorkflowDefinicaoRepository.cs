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
    public class WorkflowDefinicaoRepository : Repository<WorkflowDefinicao>, IWorkflowDefinicaoRepository
    {
        public WorkflowDefinicaoRepository(ProcessosDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkflowDefinicao>> ObterWorkflowDefinicaoComObjetos()
        {
            return await (Db as ProcessosDbContext).WorkflowsDefinicao
                .Include(p => p.PassosDefinicao)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<WorkflowDefinicao> ObterWorkflowDefinicaoPorIdComObjetos(Guid id)
        {
            return await (Db as ProcessosDbContext).WorkflowsDefinicao
                .Include(p => p.PassosDefinicao)
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}

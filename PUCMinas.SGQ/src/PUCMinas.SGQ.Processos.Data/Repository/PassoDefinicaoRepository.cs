using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Data.Repository
{
    public class PassoDefinicaoRepository : Repository<PassoDefinicao>, IPassoDefinicaoRepository
    {
        public PassoDefinicaoRepository(ProcessosDbContext context) : base(context)
        {
        }

        public async Task RemoverPorWorkflowDefinicao(Guid id)
        {
            List<PassoDefinicao> list =
                (Db as ProcessosDbContext).PassosDefinicao
                .AsNoTracking()
                .Where(p => p.WorkflowDefinicaoId == id)
                .ToList();

            foreach (PassoDefinicao pd in list)
            {
                if ((Db as ProcessosDbContext).Entry(pd).State == EntityState.Detached)
                {
                    (Db as ProcessosDbContext).PassosDefinicao.Attach(pd);
                }
            }
            (Db as ProcessosDbContext).PassosDefinicao.RemoveRange(list);
            await (Db as ProcessosDbContext).SaveChangesAsync();
        }
    }
}

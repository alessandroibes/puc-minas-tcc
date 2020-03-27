using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Data.Context;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Data.Repository
{
    public class AtividadeRepository : Repository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(ProcessosDbContext context) : base(context) { }

        public async Task<Atividade> ObterAtividadeComPassoDefinicao(Guid id)
        {
            return await (Db as ProcessosDbContext).Atividades
                .AsNoTracking()
                .Include(a => a.PassoDefinicoes)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

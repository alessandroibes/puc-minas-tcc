using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Context;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Context
{
    public class ProcessosDbContext : BaseDbContext
    {
        public ProcessosDbContext(DbContextOptions<ProcessosDbContext> options) : base(options) { }

        public DbSet<Atividade> Atividades { get; set; }
    }
}

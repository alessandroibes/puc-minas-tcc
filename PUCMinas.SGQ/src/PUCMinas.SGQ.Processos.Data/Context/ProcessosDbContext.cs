using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Context
{
    public class ProcessosDbContext : DbContext
    {
        public ProcessosDbContext(DbContextOptions<ProcessosDbContext> options) : base(options) { }

        public DbSet<Atividade> Atividades { get; set; }
    }
}

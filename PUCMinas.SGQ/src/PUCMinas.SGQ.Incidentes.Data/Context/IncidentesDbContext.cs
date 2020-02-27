using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Core.Data.Context;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Context
{
    public class IncidentesDbContext : BaseDbContext
    {
        public IncidentesDbContext(DbContextOptions<IncidentesDbContext> options) : base(options) { }

        public DbSet<RNC> NaoConformidades { get; set; }
    }
}

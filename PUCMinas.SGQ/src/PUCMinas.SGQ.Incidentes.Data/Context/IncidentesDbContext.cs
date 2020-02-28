using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Data.Context
{
    public class IncidentesDbContext : DbContext
    {
        public IncidentesDbContext(DbContextOptions<IncidentesDbContext> options) : base(options) { }

        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Causa> Causas { get; set; }
        public DbSet<Gravidade> Gravidades { get; set; }
        public DbSet<RNC> RNCs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IncidentesDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

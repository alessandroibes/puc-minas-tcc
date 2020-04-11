using Microsoft.EntityFrameworkCore;
using PUCMinas.SGQ.Processos.Business.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Processos.Data.Context
{
    public class ProcessosDbContext : DbContext
    {
        public ProcessosDbContext(DbContextOptions<ProcessosDbContext> options) : base(options) { }

        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Passo> Passos { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<PassoDefinicao> PassosDefinicao { get; set; }
        public DbSet<WorkflowDefinicao> WorkflowsDefinicao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProcessosDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

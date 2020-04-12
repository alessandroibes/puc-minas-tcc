using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class WorkflowMapping : IEntityTypeConfiguration<Workflow>
    {
        public void Configure(EntityTypeBuilder<Workflow> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Nome)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            // 1 : N => Workflow : Passos
            builder.HasMany(w => w.Passos)
                .WithOne(p => p.Workflow)
                .HasForeignKey(p => p.WorflowId);

            builder.Property(p => p.DataInicio)
                .IsRequired(false);

            builder.Property(p => p.DataFim)
                .IsRequired(false);

            builder.Property(p => p.Iniciado)
                .IsRequired(true);

            builder.Property(p => p.Finalizado)
                .IsRequired(true);

            builder.ToTable("Workflows");
        }
    }
}

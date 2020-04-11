using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class WorkflowDefinicaoMapping : IEntityTypeConfiguration<WorkflowDefinicao>
    {
        public void Configure(EntityTypeBuilder<WorkflowDefinicao> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Nome)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            // 1 : N => Workflow : Passos
            builder.HasMany(w => w.PassosDefinicao)
                .WithOne(p => p.WorkflowDefinicao)
                .HasForeignKey(p => p.WorkflowDefinicaoId);

            builder.ToTable("WorkflowsDefinicao");
        }
    }
}

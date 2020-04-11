using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class PassoMapping : IEntityTypeConfiguration<Passo>
    {
        public void Configure(EntityTypeBuilder<Passo> builder)
        {
            builder.HasKey(p => p.Id);

            // N : 1 => Passos => Workflow
            builder.HasOne(p => p.Workflow)
                .WithMany(w => w.Passos)
                .HasForeignKey(p => p.WorflowId)
                .IsRequired(true);

            // 1 : 1 => Passo : Parada
            builder.HasOne(p => p.Parada)
                .WithOne(p => p.Passo);

            builder.Property(p => p.OperadorId)
                .IsRequired(true);

            builder.Property(p => p.DataInicio)
                .IsRequired(false);

            builder.Property(p => p.DataFim)
                .IsRequired(false);

            builder.Property(p => p.Iniciado)
                .IsRequired(true);

            builder.Property(p => p.Finalizado)
                .IsRequired(true);

            builder.ToTable("Passos");
        }
    }
}

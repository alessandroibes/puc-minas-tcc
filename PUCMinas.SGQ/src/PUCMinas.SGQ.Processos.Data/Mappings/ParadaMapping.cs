using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class ParadaMapping : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired(true)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Data)
                .IsRequired(true);

            builder.Property(p => p.OperadorId)
                .IsRequired(true);

            builder.Property(p => p.IncidenteCadastrado)
                .IsRequired(true);

            // 1 : 1 => Parada : Passo
            builder.HasOne(p => p.Passo)
                .WithOne(p => p.Parada);

            builder.ToTable("Paradas");
        }
    }
}

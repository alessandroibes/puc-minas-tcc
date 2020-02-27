using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Mappings
{
    public class NaoConformidadeMapping : IEntityTypeConfiguration<RNC>
    {
        public void Configure(EntityTypeBuilder<RNC> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Ocorrencia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)");

            builder.ToTable("NaoConformidades");
        }
    }
}

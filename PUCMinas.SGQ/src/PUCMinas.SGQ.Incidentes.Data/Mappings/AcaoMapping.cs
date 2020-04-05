using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Mappings
{
    public class AcaoMapping : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            builder.ToTable("Acoes");
        }
    }
}

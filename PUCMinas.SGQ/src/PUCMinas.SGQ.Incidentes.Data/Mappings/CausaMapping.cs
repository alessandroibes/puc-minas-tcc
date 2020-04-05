using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Mappings
{
    public class CausaMapping : IEntityTypeConfiguration<Causa>
    {
        public void Configure(EntityTypeBuilder<Causa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            builder.ToTable("Causas");
        }
    }
}

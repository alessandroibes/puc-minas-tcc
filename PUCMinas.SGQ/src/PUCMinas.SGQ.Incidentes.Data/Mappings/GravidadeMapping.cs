using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Mappings
{
    public class GravidadeMapping : IEntityTypeConfiguration<Gravidade>
    {
        public void Configure(EntityTypeBuilder<Gravidade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)");

            builder.ToTable("Gravidades");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Incidentes.Business.Models;

namespace PUCMinas.SGQ.Incidentes.Data.Mappings
{
    public class RNCMapping : IEntityTypeConfiguration<RNC>
    {
        public void Configure(EntityTypeBuilder<RNC> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Ocorrencia)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)");

            // 1 : N => RNC : Gravidade
            builder.HasOne(p => p.Gravidade)
                .WithMany(g => g.RNCs)
                .HasForeignKey(g => g.GravidadeId)
                .IsRequired(true);

            // 1 : N => RNC : Causa
            builder.HasOne(p => p.Causa)
                .WithMany(g => g.RNCs)
                .HasForeignKey(g => g.CausaId)
                .IsRequired(true);

            // 1 : N => RNC : Causa
            builder.HasOne(p => p.Acao)
                .WithMany(g => g.RNCs)
                .HasForeignKey(g => g.AcaoId)
                .IsRequired(false);

            builder.ToTable("RNCs");
        }
    }
}

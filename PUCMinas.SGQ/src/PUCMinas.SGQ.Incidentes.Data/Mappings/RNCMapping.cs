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
                .IsRequired(true)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.GerenteCriador)
                .IsRequired(true);

            builder.Property(p => p.EngenheiroResponsavel)
                .IsRequired(false);

            // 1 : N => RNC : Gravidade
            builder.HasOne(p => p.Gravidade)
                .WithMany(g => g.RNCs)
                .HasForeignKey(p => p.GravidadeId)
                .IsRequired(true);

            // 1 : N => RNC : Causa
            builder.HasOne(p => p.Causa)
                .WithMany(g => g.RNCs)
                .HasForeignKey(p => p.CausaId)
                .IsRequired(true);

            // 1 : N => RNC : Causa
            builder.HasOne(p => p.Acao)
                .WithMany(g => g.RNCs)
                .HasForeignKey(p => p.AcaoId)
                .IsRequired(false);

            builder.ToTable("RNCs");
        }
    }
}

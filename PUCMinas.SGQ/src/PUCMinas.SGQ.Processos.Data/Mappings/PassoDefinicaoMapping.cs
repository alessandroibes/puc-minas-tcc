using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class PassoDefinicaoMapping : IEntityTypeConfiguration<PassoDefinicao>
    {
        public void Configure(EntityTypeBuilder<PassoDefinicao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            // N : 1 => PassosDefinicao => WorkflowDefinicao
            builder.HasOne(p => p.WorkflowDefinicao)
                .WithMany(w => w.PassosDefinicao)
                .HasForeignKey(p => p.WorkflowDefinicaoId)
                .IsRequired(true);

            builder.ToTable("PassosDefinicao");
        }
    }
}

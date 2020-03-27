using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUCMinas.SGQ.Processos.Business.Models;

namespace PUCMinas.SGQ.Processos.Data.Mappings
{
    public class AtividadeMapping : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("Atividades");
        }
    }
}

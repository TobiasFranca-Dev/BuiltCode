using BuiltCode.Domain.Models.MedicoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuiltCode.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("medicos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.Crm)
                   .HasColumnName("crm")
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(c => c.UfCrm)
                   .HasColumnName("uf_crm")
                   .IsRequired()
                   .HasColumnType("varchar(2)");

            builder.Property(c => c.Especialidade)
                   .HasColumnName("especialidade")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.HasIndex(c=> c.Crm);

            builder.HasIndex(c => c.UfCrm);



        }
    }
}

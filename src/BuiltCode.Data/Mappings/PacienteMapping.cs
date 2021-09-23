using BuiltCode.Domain.Models.PacienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuiltCode.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("pacientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.Cpf)
                   .HasColumnName("cpf")
                   .IsRequired()
                   .HasColumnType("varchar(11)");

            builder.Property(c => c.Telefone)
                   .HasColumnName("telefone")
                   .HasColumnType("varchar(20)");

            builder.Property(c => c.MedicoId)
                   .HasColumnName("medico_id")
                   .IsRequired();

            builder.HasIndex(c => c.Cpf);

        }
    }
}

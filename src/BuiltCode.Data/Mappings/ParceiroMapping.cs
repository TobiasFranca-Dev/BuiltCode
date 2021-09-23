using BuiltCode.Domain.Models.ParceiroAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuiltCode.Data.Mappings
{
    public class ParceiroMapping : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("parceiros");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.ApiKey)
                   .HasColumnName("api_key")
                   .IsRequired()
                   .HasColumnType("varchar(36)");
        }
    }
}

using BuiltCode.Application.AppServices;
using BuiltCode.Domain.Models.UsuarioAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BuiltCode.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                   .HasColumnName("email")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.Senha)
                   .HasColumnName("senha")
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.Property(c => c.Perfil)
                   .HasColumnName("perfil")
                   .IsRequired()
                   .HasColumnType("int2");

            builder.HasIndex(c => c.Email);

            builder.HasData(new Usuario()
            {
                Id = Guid.Parse("8D364048-64CD-4BB1-AC8B-341E2D03D170"),
                Email = "contato@builtcode.com.br",
                Nome = "admin",
                Senha = HashService.GerarHash("123456"),
                Perfil = EPerfil.Admin
            });
        }
    }
}

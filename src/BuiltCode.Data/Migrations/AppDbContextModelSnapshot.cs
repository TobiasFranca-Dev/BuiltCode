﻿// <auto-generated />
using System;
using BuiltCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BuiltCode.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BuiltCode.Domain.Models.MedicoAggregate.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("crm");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("especialidade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<string>("UfCrm")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("uf_crm");

                    b.HasKey("Id");

                    b.HasIndex("Crm");

                    b.HasIndex("UfCrm");

                    b.ToTable("medicos");
                });

            modelBuilder.Entity("BuiltCode.Domain.Models.PacienteAggregate.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uuid")
                        .HasColumnName("medico_id");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("Cpf");

                    b.HasIndex("MedicoId");

                    b.ToTable("pacientes");
                });

            modelBuilder.Entity("BuiltCode.Domain.Models.ParceiroAggregate.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("api_key");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("parceiros");
                });

            modelBuilder.Entity("BuiltCode.Domain.Models.UsuarioAggregate.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<short>("Perfil")
                        .HasColumnType("int2")
                        .HasColumnName("perfil");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d364048-64cd-4bb1-ac8b-341e2d03d170"),
                            Email = "contato@builtcode.com.br",
                            Nome = "admin",
                            Perfil = (short)0,
                            Senha = "E10ADC3949BA59ABBE56E057F20F883E"
                        });
                });

            modelBuilder.Entity("BuiltCode.Domain.Models.PacienteAggregate.Paciente", b =>
                {
                    b.HasOne("BuiltCode.Domain.Models.MedicoAggregate.Medico", "Medico")
                        .WithMany("Pacientes")
                        .HasForeignKey("MedicoId")
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("BuiltCode.Domain.Models.MedicoAggregate.Medico", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
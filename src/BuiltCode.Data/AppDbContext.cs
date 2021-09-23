using BuiltCode.Domain.Core.Data;
using BuiltCode.Domain.Models.MedicoAggregate;
using BuiltCode.Domain.Models.PacienteAggregate;
using BuiltCode.Domain.Models.ParceiroAggregate;
using BuiltCode.Domain.Models.UsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public Task<bool> Commint()
        {
            throw new NotImplementedException();
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}

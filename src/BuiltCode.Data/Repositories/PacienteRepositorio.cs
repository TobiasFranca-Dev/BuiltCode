using BuiltCode.Domain.Models.PacienteAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Data.Repositories
{
    public class PacienteRepositorio : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepositorio(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Paciente>> ObterPorMedico(Guid idMedico)
        {
            return await DbSet.AsNoTracking()
                              .Where(x => x.MedicoId == idMedico)
                              .ToListAsync();
        }
    }
}

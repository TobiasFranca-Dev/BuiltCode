using BuiltCode.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Models.PacienteAggregate
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<List<Paciente>> ObterPorMedico(Guid idMedico);
    }
}

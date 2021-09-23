using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.Medico
{
    public interface IMedicoService : IDisposable
    {
        Task<List<Models.MedicoAggregate.Medico>> ObterTodos();
    }
}

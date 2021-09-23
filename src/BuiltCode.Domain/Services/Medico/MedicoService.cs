using BuiltCode.Domain.Models.MedicoAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.Medico
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<List<Models.MedicoAggregate.Medico>> ObterTodos()
        {
            return await _medicoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _medicoRepository?.Dispose();
        }
    }
}

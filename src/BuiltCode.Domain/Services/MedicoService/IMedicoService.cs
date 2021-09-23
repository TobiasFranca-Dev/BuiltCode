using BuiltCode.Domain.Models.MedicoAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.MedicoService
{
    public interface IMedicoService : IDisposable
    {
        Task<List<Medico>> ObterTodos();
        Task<Medico> ObterPorId(Guid id);
        Task<Medico> ObterPorCrm(string crm, string ufCrm);
        Task<List<Medico>> ObterPorUfCrm(string ufCrm);
        Task<Medico> Cadastrar(Medico medico);
        Task Atualizar(Medico medico);
        Task Excluir(Medico medico);
    }
}

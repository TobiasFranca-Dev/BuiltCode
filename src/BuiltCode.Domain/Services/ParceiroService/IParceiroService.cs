using BuiltCode.Domain.Models.ParceiroAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.ParceiroService
{
    public interface IParceiroService : IDisposable
    {
        Task<List<Parceiro>> ObterTodos();
        Task<Parceiro> ObterPorId(Guid id);
        Task<Parceiro> ObterPorApiKey(Guid apiKey);
        Task<Parceiro> Cadastrar(Parceiro parceiro);

        Task Atualizar(Parceiro parceiro);
    }
}

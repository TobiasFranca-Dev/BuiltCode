using BuiltCode.Domain.Models.ParceiroAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.ParceiroService
{
    public class ParceiroService : IParceiroService
    {
        private readonly IParceiroRepository _parceiroRepository;

        public ParceiroService(IParceiroRepository parceiroRepository)
        {
            _parceiroRepository = parceiroRepository;
        }

        public async Task<List<Parceiro>> ObterTodos()
        {
            return await _parceiroRepository.ObterTodos();
        }

        public async Task<Parceiro> ObterPorId(Guid id)
        {
            return await _parceiroRepository.ObterPorId(id);
        }

        public async Task<Parceiro> ObterPorApiKey(Guid apiKey)
        {
            return (await _parceiroRepository.Buscar(x => x.ApiKey == apiKey)).FirstOrDefault();
        }

        public async Task<Parceiro> Cadastrar(Parceiro parceiro)
        {
            var result = await _parceiroRepository.Adicionar(parceiro);
            await _parceiroRepository.UnitOfWork.Commint();

            return result;
        }

        public async Task Atualizar(Parceiro parceiro)
        {
            _parceiroRepository.Atualizar(parceiro);

            await _parceiroRepository.UnitOfWork.Commint();
        }

        public void Dispose()
        {
            _parceiroRepository?.Dispose();
        }
    }
}

using BuiltCode.Domain.Models.MedicoAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BuiltCode.Domain.Services.MedicoService
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;   
        }

        public async Task<List<Medico>> ObterTodos()
        {
            return await _medicoRepository.ObterTodos();
        }

        public async Task<Medico> ObterPorId(Guid id)
        {
            return await _medicoRepository.ObterPorId(id);
        }

        public async Task<Medico> ObterPorCrm(string crm, string ufCrm)
        {
            return (await _medicoRepository.Buscar(x => x.Crm == crm && x.UfCrm == ufCrm)).FirstOrDefault();
        }

        public async Task<List<Medico>> ObterPorUfCrm(string ufCrm)
        {
            return (await _medicoRepository.Buscar(x => x.UfCrm == ufCrm)).ToList();
        }

        public async Task<Medico> Cadastrar(Medico medico)
        {
            var result = await _medicoRepository.Adicionar(medico);
            await _medicoRepository.UnitOfWork.Commint();

            return result;
        }

        public async Task Atualizar(Medico medico)
        {
            _medicoRepository.Atualizar(medico);
            await _medicoRepository.UnitOfWork.Commint();
        }

        public async Task Excluir(Medico medico)
        {
            await _medicoRepository.Remover(medico.Id);
            await _medicoRepository.UnitOfWork.Commint();
        }

        public void Dispose()
        {
            _medicoRepository?.Dispose();
        }

    }
}

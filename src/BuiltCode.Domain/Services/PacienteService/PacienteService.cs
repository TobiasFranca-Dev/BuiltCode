using BuiltCode.Domain.Models.PacienteAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.PacienteService
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<List<Paciente>> ObterTodos()
        {
            return await _pacienteRepository.ObterTodos();
        }

        public async Task<Paciente> ObterPorId(Guid id)
        {
            return await _pacienteRepository.ObterPorId(id);
        }

        public async Task<List<Paciente>> ObterPorMedico(Guid idMedico)
        {
            return await _pacienteRepository.ObterPorMedico(idMedico);
        }

        public async Task<Paciente> ObterPorCpf(string cpf)
        {
            return (await _pacienteRepository.Buscar(x => x.Cpf == cpf)).FirstOrDefault();
        }

        public async Task<Paciente> Cadastrar(Paciente paciente)
        {
            var result = await _pacienteRepository.Adicionar(paciente);

            await _pacienteRepository.UnitOfWork.Commint();

            return result;
        }

        public async Task Atualizar(Paciente paciente)
        {
            _pacienteRepository.Atualizar(paciente);

            await _pacienteRepository.UnitOfWork.Commint();
        }

        public async Task Excluir(Paciente paciente)
        {
            await _pacienteRepository.Remover(paciente.Id);
            await _pacienteRepository.UnitOfWork.Commint();
        }

        public void Dispose()
        {
            _pacienteRepository?.Dispose();
        }

    }
}

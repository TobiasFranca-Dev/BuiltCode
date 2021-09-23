using BuiltCode.Domain.Models.PacienteAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.PacienteService
{
    public interface IPacienteService : IDisposable
    {
        Task<List<Paciente>> ObterTodos();
        Task<List<Paciente>> ObterPorMedico(Guid idMedico);
        Task<Paciente> ObterPorId(Guid id);
        Task<Paciente> ObterPorCpf(string cpf);
        Task<Paciente> Cadastrar(Paciente paciente);
        Task Atualizar(Paciente paciente);
        Task Excluir(Paciente paciente);
    }
}

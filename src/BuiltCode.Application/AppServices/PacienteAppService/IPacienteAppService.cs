using BuiltCode.Application.Dto.PacienteViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.PacienteAppService
{
    public interface IPacienteAppService : IDisposable
    {
        Task<List<PacienteResponseViewModel>> ObterTodos();
        Task<List<PacienteResponseViewModel>> ObterPorMedico(Guid idMedico);
        Task<PacienteResponseViewModel> ObterPorId(Guid id);
        Task<PacienteResponseViewModel> Cadastrar(PacienteRegistroViewModel viewModel);
        Task<PacienteResponseViewModel> Atualizar(Guid id, PacienteRegistroViewModel viewModel);
        Task Excluir(Guid id);


    }
}

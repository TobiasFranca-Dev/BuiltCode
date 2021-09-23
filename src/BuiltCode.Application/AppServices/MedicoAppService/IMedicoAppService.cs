using BuiltCode.Application.Dto.MedicoViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.MedicoAppService
{
    public interface IMedicoAppService : IDisposable
    {
        Task<List<MedicoResponseViewModel>> ObterTodos();
        Task<List<MedicoResponseViewModel>> ObterPorUfCrm(string ufCrm);

        Task<MedicoResponseViewModel> Cadastrar(MedicoRegistroViewModel viewModel);

        Task<MedicoResponseViewModel> Atualizar(Guid id, MedicoRegistroViewModel viewModel);

        Task Excluir(Guid id);
    }
}

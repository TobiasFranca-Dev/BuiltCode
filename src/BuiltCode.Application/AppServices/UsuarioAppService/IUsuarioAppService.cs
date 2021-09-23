using BuiltCode.Application.Dto.UsuariosViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Application.AppServices.UsuarioAppService
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<UserLoginResponseViewModel> Login(LoginViewModel viewModel);

        Task<List<UsuarioListViewModel>> ObterTodos();

        Task<UsuarioListViewModel> Adicionar(UsuarioRegistroViewModel usuarioRegistro);
        
    }
}

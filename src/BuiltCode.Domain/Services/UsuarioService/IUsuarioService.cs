using BuiltCode.Domain.Models.UsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.UsuarioService
{
    public interface IUsuarioService : IDisposable
    {
        Task<Usuario> Login(string email, string senha);
        Task<Usuario> ObterPorEmail(string email);
        Task<List<Usuario>> ObterTodos();
        Task<Usuario> Cadastrar(Usuario usuario);
    }
}

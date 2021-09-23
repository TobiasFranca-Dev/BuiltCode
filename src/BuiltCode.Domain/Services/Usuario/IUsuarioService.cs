using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.Usuario
{
    public interface IUsuarioService : IDisposable
    {
        Task<Models.UsuarioAggregate.Usuario> Login(string email, string senha);

        Task<List<Models.UsuarioAggregate.Usuario>> ObterTodos();
    }
}

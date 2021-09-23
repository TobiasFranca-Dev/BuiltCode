using BuiltCode.Domain.Models.UsuarioAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Models.UsuarioAggregate.Usuario> Login(string email, string senha)
        {
            return await _usuarioRepository.Login(email, senha);
        }

        public async Task<List<Models.UsuarioAggregate.Usuario>> ObterTodos()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
using BuiltCode.Domain.Models.UsuarioAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            return await _usuarioRepository.Login(email, senha);
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return (await _usuarioRepository.Buscar(x => x.Email.ToLower() == email.ToLower())).FirstOrDefault();
        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {

            var result = await _usuarioRepository.Adicionar(usuario);
            await _usuarioRepository.UnitOfWork.Commint();

            return result;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}
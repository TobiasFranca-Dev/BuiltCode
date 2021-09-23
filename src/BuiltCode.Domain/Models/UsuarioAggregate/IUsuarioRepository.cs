using BuiltCode.Domain.Core.Data;
using System.Threading.Tasks;

namespace BuiltCode.Domain.Models.UsuarioAggregate
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> Login(string email, string senha);
    }
}

using BuiltCode.Domain.Models.UsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BuiltCode.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context): base(context)
        {
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Senha == senha);
        }
    }
}

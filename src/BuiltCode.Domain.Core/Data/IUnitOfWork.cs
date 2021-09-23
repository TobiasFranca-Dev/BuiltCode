using System.Threading.Tasks;

namespace BuiltCode.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commint();
    }
}

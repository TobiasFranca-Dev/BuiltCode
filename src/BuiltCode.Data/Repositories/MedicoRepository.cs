using BuiltCode.Domain.Models.MedicoAggregate;

namespace BuiltCode.Data.Repositories
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(AppDbContext context) : base(context)
        {
        }
    }
}

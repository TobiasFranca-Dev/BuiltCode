using BuiltCode.Domain.Models.ParceiroAggregate;

namespace BuiltCode.Data.Repositories
{
    public class ParceiroRepository : Repository<Parceiro>, IParceiroRepository
    {
        public ParceiroRepository(AppDbContext context): base(context)
        {
        }
    }
}

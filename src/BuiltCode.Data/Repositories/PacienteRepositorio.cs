using BuiltCode.Domain.Models.PacienteAggregate;

namespace BuiltCode.Data.Repositories
{
    public class PacienteRepositorio : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepositorio(AppDbContext context) : base(context)
        {

        }
    }
}

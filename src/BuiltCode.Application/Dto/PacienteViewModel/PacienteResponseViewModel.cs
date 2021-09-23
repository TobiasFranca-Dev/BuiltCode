using BuiltCode.Application.Dto.MedicoViewModel;
using System;

namespace BuiltCode.Application.Dto.PacienteViewModel
{
    public class PacienteResponseViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Guid MedicoId { get; set; }

        /*EntityFramework Relation*/
        public MedicoResponseViewModel Medico { get; set; }
    }
}

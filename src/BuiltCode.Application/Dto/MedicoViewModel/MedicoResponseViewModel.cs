using BuiltCode.Application.Dto.PacienteViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltCode.Application.Dto.MedicoViewModel
{
    public class MedicoResponseViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string UfCrm { get; set; }
        public string Especialidade { get; set; }
        
        public IEnumerable<PacienteResponseViewModel> Pacientes { get; set; }
    }
}

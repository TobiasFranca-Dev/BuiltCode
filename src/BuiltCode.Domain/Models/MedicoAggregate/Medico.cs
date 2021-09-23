using BuiltCode.Domain.Core;
using BuiltCode.Domain.Core.DomainObjects;
using BuiltCode.Domain.Models.PacienteAggregate;
using System.Collections.Generic;

namespace BuiltCode.Domain.Models.MedicoAggregate
{
    public class Medico : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string UfCrm { get; set; }
        public string Especialidade { get; set; }

        /*EntityFramework Relation*/
        public IEnumerable<Paciente> Pacientes { get; set; }
    }
}

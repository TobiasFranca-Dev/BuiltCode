using BuiltCode.Domain.Core;
using BuiltCode.Domain.Core.DomainObjects;
using BuiltCode.Domain.Models.MedicoAggregate;
using System;

namespace BuiltCode.Domain.Models.PacienteAggregate
{
    public class Paciente : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Guid MedicoId { get; set; }

        /*EntityFramework Relation*/
        public Medico Medico { get; set; }
    }
}

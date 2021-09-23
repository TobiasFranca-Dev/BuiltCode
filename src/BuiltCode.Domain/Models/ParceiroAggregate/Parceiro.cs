using BuiltCode.Domain.Core;
using BuiltCode.Domain.Core.DomainObjects;
using System;

namespace BuiltCode.Domain.Models.ParceiroAggregate
{
    public class Parceiro : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public Guid ApiKey { get; set; }
    }
}

using BuiltCode.Domain.Core;
using BuiltCode.Domain.Core.DomainObjects;
using BuiltCode.Domain.Models.UsuarioAggregate.Enums;

namespace BuiltCode.Domain.Models.UsuarioAggregate
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public EPerfil Perfil { get; set; }

    }
}

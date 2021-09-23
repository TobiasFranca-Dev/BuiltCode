using System;

namespace BuiltCode.Application.Dto.UsuariosViewModel
{
    public class UsuarioListViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
    }
}

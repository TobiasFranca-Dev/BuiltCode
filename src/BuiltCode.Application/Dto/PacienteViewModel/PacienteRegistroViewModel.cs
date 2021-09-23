using BuiltCode.Application.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BuiltCode.Application.Dto.PacienteViewModel
{
    public class PacienteRegistroViewModel
    {
        
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }


        [CpfValidator(ErrorMessage = "CPF inválido!")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Cpf { get; set; }

        
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(36, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public Guid MedicoId { get; set; }

    }
}

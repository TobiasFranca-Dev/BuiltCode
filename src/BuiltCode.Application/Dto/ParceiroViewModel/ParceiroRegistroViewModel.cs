using System.ComponentModel.DataAnnotations;

namespace BuiltCode.Application.Dto.ParceiroViewModel
{
    public class ParceiroRegistroViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }
    }
}

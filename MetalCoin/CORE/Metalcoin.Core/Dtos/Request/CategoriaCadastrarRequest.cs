using System.ComponentModel.DataAnnotations;

namespace Metalcoin.Core.Dtos.Categorias
{
    public record CategoriaCadastrarRequest
    {
        [Required (ErrorMessage = "Nome da categoria é obrigátorio")]
        [MaxLength(25, ErrorMessage = "Categoria pode ter no máximo 25 letras")]
        [MinLength(3, ErrorMessage = "Categoria deve ter no mínimo 3 letras")]
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}

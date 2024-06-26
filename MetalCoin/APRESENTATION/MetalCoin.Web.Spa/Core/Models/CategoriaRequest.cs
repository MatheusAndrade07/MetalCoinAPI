using System.ComponentModel.DataAnnotations;

namespace MetalCoin.Web.Spa.Core.Models
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage ="O nome da categoria é obrigatório")]
        public string Nome { get; set; }
        
        public bool Status { get; set; }
    }
}

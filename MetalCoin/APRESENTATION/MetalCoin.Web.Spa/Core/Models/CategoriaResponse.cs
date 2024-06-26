namespace MetalCoin.Web.Spa.Core.Models
{
    public class CategoriaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public DateTime Alterado { get; set; }
        public DateTime Criado { get; set; }
        public int QuantidadeProdutosVinculados { get; set; }

    }
}

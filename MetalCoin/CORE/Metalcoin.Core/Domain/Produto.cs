using Metalcoin.Core.Abstracts;

namespace Metalcoin.Core.Domain
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }              
    }
}

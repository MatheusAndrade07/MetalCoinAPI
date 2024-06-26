using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Enums;

namespace Metalcoin.Core.Domain
{
    public class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public bool Status { get; set; }
        public Endereco Endereco { get; set; }

        /* EF Relation */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}

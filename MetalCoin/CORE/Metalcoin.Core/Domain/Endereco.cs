using Metalcoin.Core.Abstracts;

namespace Metalcoin.Core.Domain
{
    public class Endereco : Entidade
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }

        /* EF Relation */
        public Fornecedor? Fornecedor { get; set; }
        public Guid FornecedorId { get; set; }
    }
}

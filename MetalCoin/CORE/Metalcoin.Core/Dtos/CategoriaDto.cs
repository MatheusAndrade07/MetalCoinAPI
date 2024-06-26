using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int QuantidadeProdutosVinculados { get; set; }

    }
}

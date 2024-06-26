using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Response
{
    public class InssCalculoResponse
    {
        public double SalarioBase { get; set; }
        public double ValorDesconto { get; set; }
        public double SalarioLiquido { get; set; }
        public string Aliquota { get; set; }
    }
}

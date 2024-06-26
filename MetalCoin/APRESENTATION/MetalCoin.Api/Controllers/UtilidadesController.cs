using Metalcoin.Core.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class UtilidadesController
    {
        [HttpGet]
        [Route("api/utilidades/calcula-inss")]
        public InssCalculoResponse CalculaInss(double salario)
        {
            var inssCalculado = new InssCalculoResponse();
            inssCalculado.SalarioBase = salario;

            if (salario <= 1045)
            {
                inssCalculado.Aliquota = "7,5%";
                inssCalculado.ValorDesconto = salario * 0.075;
                inssCalculado.SalarioLiquido = salario - inssCalculado.ValorDesconto;
                return inssCalculado;
            }
            else if (salario <= 2089.60)
            {
                inssCalculado.Aliquota = "9%";
                inssCalculado.ValorDesconto = salario * 0.090;
                inssCalculado.SalarioLiquido = salario - inssCalculado.ValorDesconto;
                return inssCalculado;
            }
            else if (salario <= 3134.40)
            {
                inssCalculado.Aliquota = "12%";
                inssCalculado.ValorDesconto = salario * 0.12;
                inssCalculado.SalarioLiquido = salario - inssCalculado.ValorDesconto;
                return inssCalculado;
            }
            else
            {
                inssCalculado.Aliquota = "14%";
                inssCalculado.ValorDesconto = salario * 0.14;
                inssCalculado.SalarioLiquido = salario - inssCalculado.ValorDesconto;
                return inssCalculado;
            }
        }
    }
}

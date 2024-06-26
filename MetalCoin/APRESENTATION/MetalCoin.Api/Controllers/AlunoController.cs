using Metalcoin.Core.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class AlunoController
    {
        [HttpGet]
        [Route("api/aluno")]
        public AlunoResponse GetAluno(string cpf)
        {
            
            var aluno = new AlunoResponse
            {
                Cpf = "12345678901",
                Nome = "João da Silva",
                Status = "Ativo",
                Curso = "Engenharia de Software",
                Turno = "Noturno"
            };
            return aluno;
        }   
    }
}

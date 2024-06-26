using MetalCoin.Web.Spa.Core.Models;
using System.Reflection.Metadata.Ecma335;

namespace MetalCoin.Web.Spa.Core.Endpoint
{
    public interface ICategoriaEndpoint
    {
        Task Cadastrar(CategoriaRequest request);
        Task Atualizar(CategoriaRequest request);
        Task Remover(Guid Id);
        Task Ativar(Guid Id);
        Task Desativar(Guid Id);
        Task<CategoriaResponse> ObterUm(string Id);
        Task<List<CategoriaResponse>> ObterTodos();
    }
    public class CategoriaEndpoint : ICategoriaEndpoint
    {
        public Task Ativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(CategoriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(CategoriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Desativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaResponse>> ObterTodos()
        {
            var response = new List<CategoriaResponse>();
            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Eletrônicos",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-30),
                QuantidadeProdutosVinculados = 120
            });

            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Roupas",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-50),
                QuantidadeProdutosVinculados = 300
            });

            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Livros",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-20),
                QuantidadeProdutosVinculados = 80
            });

            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Móveis",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-70),
                QuantidadeProdutosVinculados = 200
            });

            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Alimentos",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-10),
                QuantidadeProdutosVinculados = 150
            });

            response.Add(new CategoriaResponse
            {
                Id = Guid.NewGuid(),
                Nome = "Esportes",
                Status = true,
                Alterado = DateTime.UtcNow,
                Criado = DateTime.UtcNow.AddDays(-40),
                QuantidadeProdutosVinculados = 180
            });
            return Task.FromResult(response);
        }
        public Task<CategoriaResponse> ObterUm(string Id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

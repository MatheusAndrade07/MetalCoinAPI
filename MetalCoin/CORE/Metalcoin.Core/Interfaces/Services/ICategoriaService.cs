using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;

namespace Metalcoin.Core.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaResponse> CadastrarCategoria(CategoriaCadastrarRequest categoria);
        Task<CategoriaResponse> AtualizarCategoria(CategoriaAtualizarRequest categoria);
        Task<bool> DeletarCategoria(Guid id);

        Task<List<CategoriaResponse>> ObterTodasAsCategoriasAtivas();
    }
}

using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ProdutoResponse> CadastrarProduto(ProdutoCadastrarRequest produto);
        Task<ProdutoResponse> AtualizarProduto(ProdutoAtualizarRequest produto);
        Task<bool> DeletarProduto(Guid id);
    }
}

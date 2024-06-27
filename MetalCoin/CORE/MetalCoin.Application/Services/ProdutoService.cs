using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository repository)
        {
            _produtoRepository = repository;
        }

        public async Task<ProdutoResponse> AtualizarProduto(ProdutoAtualizarRequest produto)
        {
            var produtoDb = await _produtoRepository.ObterPorId(produto.Id);

            produtoDb.Status = produto.Status;
            produto.Nome = produto.Nome.ToUpper();
            produtoDb.DataAlteracao = DateTime.Now;

            await _produtoRepository.Atualizar(produtoDb);

            var response = new ProdutoResponse
            {
                Id = produtoDb.Id,
                Nome = produtoDb.Nome,
                Status = produtoDb.Status,
                DataAlteracao = produtoDb.DataAlteracao,
                DataCadastro = produtoDb.DataCadastro
            };

            return response;
        }

        public async Task<ProdutoResponse> CadastrarProduto(ProdutoCadastrarRequest produto)
        {

            var produtoExistente = await _produtoRepository.BuscarPorNome(produto.Nome);

            if (produtoExistente != null) return null;

            var produtoEntidade = new Produto
            {
                Nome = produto.Nome.ToUpper(),
                Status = produto.Status,
                Descricao = produto.Descricao,
                Valor = produto.Valor,                
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now
            };

            await _produtoRepository.Adicionar(produtoEntidade);

            var response = new ProdutoResponse
            {
                Id = produtoEntidade.Id,
                Nome = produtoEntidade.Nome,
                Status = produtoEntidade.Status,
                DataCadastro = produtoEntidade.DataCadastro,
                DataAlteracao = produtoEntidade.DataAlteracao
            };

            return response;
        }

        public async Task<bool> DeletarProduto(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            if (produto == null) return false;


            await _produtoRepository.Remover(id);
            return true;
        }
    }
}

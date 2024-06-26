using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoRepository produtoRepository, IProdutoService produtoService)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("todosprodutos")]
        public async Task<ActionResult> ObterTodasProduto()
        {
            var listaProduto = await _produtoRepository.ObterTodos();

            if (listaProduto.Count == 0) return NoContent();

            return Ok(listaProduto);
        }


        [HttpGet]
        [Route("{idprodutos:guid}")]
        public async Task<ActionResult> ObterUmaCategoria(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            if (produto == null) return BadRequest("Produto não encontrado");
            return Ok(produto);
        }


        [HttpPost]
        [Route("cadastrarproduto")]
        public async Task<ActionResult> CadastrarProduto([FromBody] ProdutoCadastrarRequest produto)
        {
            if (produto == null) return BadRequest("Informe o nome do produto!");

            var response = await _produtoService.CadastrarProduto(produto);

            if (response == null) return BadRequest("Produto já existe");

            return Created("cadastrar", response);
        }


        [HttpPut]
        [Route("atualizarproduto")]
        public async Task<ActionResult> AtualizarProduto([FromBody] ProdutoAtualizarRequest produto)
        {
            if (produto == null) return BadRequest("Nenhum valor chegou na API");

            var response = await _produtoService.AtualizarProduto(produto);

            return Ok(response);
        }

        [HttpDelete]
        [Route("deletarproduto/{id:guid}")]
        public async Task<ActionResult> RemoverProduto(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não informado");

            var resultado = await _produtoService.DeletarProduto(id);

            if (!resultado) return BadRequest("O Produto que está tentando deletar não existe");

            return Ok("Produto deletada com sucesso");
        }
    }
}

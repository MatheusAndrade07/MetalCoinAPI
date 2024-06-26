using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        
        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<ActionResult> ObterTodasCategorias()
        {
            var listaCategorias = await _categoriaRepository.ObterTodos();

            if(listaCategorias.Count == 0) return NoContent();

            return Ok(listaCategorias);
        }

        [HttpGet]
        [Route("todos/ativas")]
        public async Task<ActionResult> ObterTodasCategoriasAtivas()
        {
            var listaCategorias = await _categoriaService.ObterTodasAsCategoriasAtivas();

            if (listaCategorias.Count == 0) return NoContent();

            return Ok(listaCategorias);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> ObterUmaCategoria(Guid id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);
            if (categoria == null) return BadRequest("Categoria não encontrada");
            return Ok(categoria);
        }


        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> CadastrarCategoria([FromBody]CategoriaCadastrarRequest categoria)
        {
            if (categoria == null) return BadRequest("Informe o nome da categoria");
            
            var response = await _categoriaService.CadastrarCategoria(categoria);

            if(response == null) return BadRequest("Categoria já existe");

            return Created("cadastrar", response);
        }


        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult> AtualizarCategoria([FromBody] CategoriaAtualizarRequest categoria)
        {
            if (categoria == null) return BadRequest("Nenhum valor chegou na API");

            var response =  await _categoriaService.AtualizarCategoria(categoria);

            return Ok(response);
        }

        [HttpDelete]
        [Route("deletar/{id:guid}")]
        public async Task<ActionResult> RemoverCategoria(Guid id)
        {
            if(id ==  Guid.Empty) return BadRequest("Id não informado");

            var resultado = await _categoriaService.DeletarCategoria(id);

            if (!resultado) return BadRequest("A categoria que está tentando deletar não existe");
                
            return Ok("Categoria deletada com sucesso");
        }
    }
}
